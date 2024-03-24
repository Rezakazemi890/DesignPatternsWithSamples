#region Creational

//Singleton
AddTitle("Singleton:");

var instance1 = Singleton.GetInstance();
var instance2 = Singleton.GetInstance();
Console.WriteLine($"References Are Equal? {ReferenceEquals(instance1, instance2)}");

LogSeparator();

//Simple Factory
AddTitle("SimpleFactory:");

var desk = SimpleFactory.DeskFactory.MakeDesk(80, 30, 40);
Console.WriteLine(
    $"woodenDesk height: {desk.GetHeight()} - width: {desk.GetWidth()} - length: {desk.GetLength()}");

LogSeparator();

//Factory Method
AddTitle("Factory Method:");

var woodenChairSeller = new FactoryMethod.WoodenChairSeller();
woodenChairSeller.SellChair();

var metalChairSeller = new FactoryMethod.MetalChairSeller();
metalChairSeller.SellChair();

LogSeparator();

//Builder
AddTitle("Builder:");

var burger = new Builder.BurgerBuilder(15)
    .AddCheese()
    .AddLettuce()
    .AddPepperoni()
    .Build();
Console.WriteLine(burger.GetDescription());

LogSeparator();

//Abstract
AddTitle("Abstract:");

AbstractFactory.IWindowFactory woodenWindowFactory = new AbstractFactory.WoodenWindowFactory();
AbstractFactory.IWindow woodenWindow = woodenWindowFactory.MakeWindow();
AbstractFactory.IWindowFittingExpert woodenWindowFittingExpert = woodenWindowFactory.MakeFittingExpert();
woodenWindow.GetDescription();
woodenWindowFittingExpert.GetDescription();

AbstractFactory.IWindowFactory ironWindowFactory = new AbstractFactory.IronWindowFactory();
AbstractFactory.IWindow ironWindow = ironWindowFactory.MakeWindow();
AbstractFactory.IWindowFittingExpert ironWindowFittingExpert = ironWindowFactory.MakeFittingExpert();
ironWindow.GetDescription();
ironWindowFittingExpert.GetDescription();

LogSeparator();

//Prototype
AddTitle("Prototype");

var originalCircle = new Prototype.Circle { Radius = 5 };
// Clone the prototype
var clonedCircle = (Prototype.Circle)originalCircle.Clone();

originalCircle.Draw();
clonedCircle.Draw();

LogSeparator();
#endregion

#region Structural

//Adapter
AddTitle("Adapter:");

Adapter.EuropeanSocket europeanSocket = new Adapter.EuropeanSocket();
Adapter.IPersianSocket persianSocket = new Adapter.SocketAdapter(europeanSocket);

Console.WriteLine("Client: Connecting Persian device to socket.");
persianSocket.Connect();

LogSeparator();

//Decorator
AddTitle("Decorator:");

Decorator.IPizza plainPizza = new Decorator.PlainPizza();
Decorator.IPizza cheesePizza = new Decorator.CheeseDecorator(plainPizza);
Decorator.IPizza tomatoPizza = new Decorator.TomatoDecorator(cheesePizza);

Console.WriteLine($"Plain Pizza: {plainPizza.GetDescription()}, Cost: {plainPizza.GetCost()}T");
Console.WriteLine($"Cheese Pizza: {cheesePizza.GetDescription()}, Cost: {cheesePizza.GetCost()}T");
Console.WriteLine($"Deluxe Pizza: {tomatoPizza.GetDescription()}, Cost: {tomatoPizza.GetCost()}T");

LogSeparator();

//Proxy
AddTitle("Proxy:");

Proxy.ISensitiveData adminData = new Proxy.SensitiveDataProxy("Admin");
Proxy.ISensitiveData regularUser = new Proxy.SensitiveDataProxy("User");

adminData.AccessData();
regularUser.AccessData();

LogSeparator();

//Facade
AddTitle("Facade:");

var facadeOperator = new Facade.FacadeOperator();
facadeOperator.PerformOperations();

LogSeparator();

//Bridge
AddTitle("Bridge");

Bridge.Shape redCircle = new Bridge.BridgeCircle(10, 10, 5, new Bridge.DrawApi1());
redCircle.Draw();

LogSeparator();

//Composite
AddTitle("Composite");

// Create leaf objects
var circle1 = new Composite.CompositeCircle();
var circle2 = new Composite.CompositeCircle();

// Create composite object
var compositeGraphic = new Composite.CompositeGraphic();
compositeGraphic.Add(circle1);
compositeGraphic.Add(circle2);

// Draw individual objects and the composite object
circle1.Draw();
circle2.Draw();
compositeGraphic.Draw();

LogSeparator();

//Flyweight
AddTitle("Flyweight");

var shapeFactory = new Flyweight.ShapeFactory();

var flyCircle1 = shapeFactory.GetShape("5");
flyCircle1.Draw(1, 2);

var flyCircle2 = shapeFactory.GetShape("10");
flyCircle2.Draw(3, 4);

LogSeparator();
#endregion

#region Behavioral

//Observer
AddTitle("Observer:");

Observer.WeatherStation weatherStation = new Observer.WeatherStation();
Observer.IObserver observer1 = new Observer.ConcreteObserver("Observer 1");
Observer.IObserver observer2 = new Observer.ConcreteObserver("Observer 2");
Observer.IObserver observer3 = new Observer.ConcreteObserver("Observer 3");

weatherStation.Attach(observer1);
weatherStation.Attach(observer2);
weatherStation.Attach(observer3);

weatherStation.SetTemperature(25.5f);

weatherStation.Detach(observer2);

weatherStation.SetTemperature(28.0f);

LogSeparator();

//Strategy
AddTitle("Strategy:");

Strategy.ShoppingCart cart = new Strategy.ShoppingCart();

Strategy.IPaymentStrategy creditCardPayment = new Strategy.CreditCardPaymentStrategy("123456789");
Strategy.IPaymentStrategy paypalPayment = new Strategy.PayPalPaymentStrategy("user@gmail.com");

cart.SetPaymentStrategy(creditCardPayment);
cart.Checkout(50000);

cart.SetPaymentStrategy(paypalPayment);
cart.Checkout(80000);

LogSeparator();

//Chain Of Responsibility
AddTitle("Chain Of Responsibility:");

ChainOfResponsibility.IHelpDeskHandler helpDeskHandler = new ChainOfResponsibility.LevelOneSupport();

var lowSeverityTicket =
    new ChainOfResponsibility.HelpDeskTicket(Severity: 1, Description: "Printer issue");
var mediumSeverityTicket =
    new ChainOfResponsibility.HelpDeskTicket(Severity: 2, Description: "Software problem");
var highSeverityTicket =
    new ChainOfResponsibility.HelpDeskTicket(Severity: 4, Description: "Server down");

helpDeskHandler.HandleTicket(lowSeverityTicket);
helpDeskHandler.HandleTicket(mediumSeverityTicket);
helpDeskHandler.HandleTicket(highSeverityTicket);

LogSeparator();

//Command
AddTitle("Command:");

Command.RemoteControl remote = new Command.RemoteControl();
Command.Light livingRoomLight = new Command.Light();
Command.Tv livingRoomTv = new Command.Tv();

Command.ICommand livingRoomLightOn = new Command.LightOnCommand(livingRoomLight);
Command.ICommand livingRoomLightOff = new Command.LightOffCommand(livingRoomLight);
Command.ICommand livingRoomTvOn = new Command.TvOnCommand(livingRoomTv);
Command.ICommand livingRoomTvOff = new Command.TvOffCommand(livingRoomTv);

remote.SetCommand(livingRoomLightOn, livingRoomLightOff);
remote.SetCommand(livingRoomTvOn, livingRoomTvOff);

remote.PressOnButton(0);
remote.PressOffButton(0);
remote.PressOnButton(1);
remote.PressOffButton(1);

LogSeparator();

//Mediator

AddTitle("Mediator:");

Mediator.IAirTrafficControl atc = new Mediator.AirTrafficControl();

Mediator.IAircraft aircraft1 = new Mediator.Aircraft("Flight123", atc);
Mediator.IAircraft aircraft2 = new Mediator.Aircraft("Flight456", atc);
Mediator.IAircraft aircraft3 = new Mediator.Aircraft("Flight789", atc);

aircraft1.SendWarning("Traffic ahead.");
aircraft2.SendWarning("Turbulence reported.");
aircraft3.SendWarning("Hijack Warning.");

LogSeparator();

//State
AddTitle("State");

State.TrafficLight trafficLight = new State.TrafficLight();

// Simulate traffic light changes
trafficLight.Change(); // Red to Yellow
trafficLight.Change(); // Yellow to Green
trafficLight.Change(); // Green to Red

LogSeparator();

//Template Method

AddTitle("Template Method");

Console.WriteLine("Making tea:");
TemplateMethod.Tea tea = new TemplateMethod.Tea();
tea.PrepareBeverage();

Console.WriteLine("\nMaking coffee:");
TemplateMethod.Coffee coffee = new TemplateMethod.Coffee();
coffee.PrepareBeverage();

LogSeparator();

//Visitor

AddTitle("Visitor");

var shapes = new List<Visitor.IShape>
{
    new Visitor.Circle(3),
    new Visitor.Square(4),
    new Visitor.Circle(5),
    new Visitor.Square(2)
};

var areaCalculator = new Visitor.AreaCalculator();

foreach (var shape in shapes)
{
    shape.Accept(areaCalculator);
}

LogSeparator();

//Iterator
AddTitle("Iterator");

var aggregate = new Iterator.ConcreteAggregate();
var iterator = aggregate.GetIterator();

while (iterator.HasNext())
{
    var item = iterator.Next();
    Console.WriteLine(item);
}

LogSeparator();

//Memento
AddTitle("Memento");

var originator = new Memento.Originator();
var caretaker = new Memento.Caretaker();

originator.State = "State1";
Console.WriteLine($"Current State: {originator.State}");

caretaker.Memento = originator.CreateMemento();

originator.State = "State2";
Console.WriteLine($"Updated State: {originator.State}");

originator.RestoreMemento(caretaker.Memento);
Console.WriteLine($"Restored State: {originator.State}");

LogSeparator();

//Interpreter
AddTitle("Interpreter");

Interpreter.IExpression expression = new Interpreter.AddExpression(new Interpreter.NumberExpression(1), new Interpreter.NumberExpression(2));

var context = new Interpreter.Context();
expression.Interpret(context);

Console.WriteLine("Result: " + context.Output);  // Result: 3

LogSeparator();
#endregion

#region Utils

Console.ReadLine();
return;

void LogSeparator()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("*****************************************************************");
    Console.ResetColor();
}

void AddTitle(string title)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(title);
    Console.ResetColor();
}

#endregion