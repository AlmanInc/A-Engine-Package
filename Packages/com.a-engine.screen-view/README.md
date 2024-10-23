После установки пакета A-Engine - Screen View, можно приступать к работе с меню.

1) Основные объекты пакета:
>>> Screen View Manager. Это основной класс для управления переходами между сценами. Именно здесь осуществляется основная логика.

>>> Screen View. Это класс конкретного меню игры, работает в тесной взаимосвязи с Screen View Manager. Объектов этого класса может быть несколько на Unity сцене или только один. Множество объектов будут реализовывать логику панелей-меню, которые переключаются в процессе работы приложения.

>>> Screen View Configuration. Вспомогательный класс с некоторыми общими настройками.


2) Прежде всего, в папке Resources необходимо создать файл настроек Screen View Configuration:
Правая кнопка мыши -> Create -> Screen View Configuration.

При необходимости можно задать требуемые настройки.


3) На каждой Unity сцене должен быть объект с компонентом Screen View Manager. Можно воспользоваться префабом из пакета. Помимо менеджера меню, для каждой сцены должен быть актуальный набор объектов с компонентами-наследниками от Screen View. Рекомендуется объект с компонентом Screen View Manager сделать корневым для объектов с Screen View (наследниками Screen View). 

Для каждой сцены, объекту Screen View Manager в поле Default Screen View необходимо назначить меню (Screen View) по-умолчанию. При первом запуске игры или при открытии сцены без уточнения, какое Screen View нужно открыть, будет загружаться Screen View по-умолчанию.


4) Скорее всего, из одного Screen View потребуется осуществлять переходы в другие Screen View. Рекомендуется объект Screen View Manager сделать легко доступным, например, через задания зависимостей Zenject, использовании подхода синглтон или любой другой способ. Можно также сделать базовый класс BaseScreenView для всех игровых Screen View, который будет внедрять зависимость с Screen View Manager и делать его доступным для использования.

Каждый наследник Screen View должен также переопределять текстовое свойство Kind. Kind должен быть уникальным для каждого Screen View в рамках одной и той же Unity сцены.

Каждый Screen View содержит поле для панели, содержащей графику, отображающую соответствующий экран меню.


5) На данном этапе пакет уже полностью настроен и готов к работе.

Screen View Manager:
public void OpenScene(Enum scene, ParamsData paramsData = null)
public void OpenScene(string scene, ParamsData paramsData = null)

Методы открывают Unity сцену. Т.к. конкретное Screen View не указано, будет открыта сцена по-умолчанию (пункт 3)


public void OpenScreenView(Enum screenView, ParamsData paramsData = null)
public void OpenScreenView(string screenView, ParamsData paramsData = null)

Методы открывают ScreenView с соответствующим Kind в рамках текущей сцены.


public void OpenScreenView(Enum scene, Enum screenView, ParamsData paramsData = null)
public void OpenScreenView(string scene, string screenView, ParamsData paramsData = null)

Методы открывают требуемую сцену и требуемый ScreenView на данной сцене


ParamsData позволяет передавать в ScreenView любые параметры


6) Основной интерфейс Screen View:

protected virtual void Initialize() 

Одноразовая инициализация ScreenView


public virtual void Activate(ParamsData data)

Активация ScreenView. Также делает видимой панель с графикой (base.Activate)


public virtual void Deactivate()

Деактивирует ScreenView, но не выключает панель с графикой. Отключение панели происходит уже после деактивации и данный функционал не является переопределяемым.


Активация и деактивация не включают-выключают сами меню c ScreenView, так что процессы, такие как анимации, в случае необходимости нужно останавливать явно.
