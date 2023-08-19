using DesignPattern.Behavioral;
using DesignPattern.Creational;
using DesignPattern.Structural;

#region Creational

//Singleton
AddTitle("Singleton:");

var instance = Singleton.GetInstance();
Console.WriteLine($"{instance.GetHashCode().ToString()}");

LogSeperator();

//Simple Factory
AddTitle("SimpleFactory:");

var desk = SimpleFactory.DeskFactory.MakeDesk(80, 30, 40);
Console.WriteLine(
    $"woodenDesk height: {desk.GetHeight()} - width: {desk.GetWidth()} - length: {desk.GetLength()}");

LogSeperator();

//Factory Method
AddTitle("Factory Method:");

var woodenChairSeller = new FactoryMethod.WoodenChairSeller();
woodenChairSeller.SellChair();

var metalChairSeller = new FactoryMethod.MetalChairSeller();
metalChairSeller.SellChair();

LogSeperator();

//Builder
AddTitle("Builder:");

var burger = new Builder.BurgerBuilder(15)
    .AddCheese()
    .AddLettuce()
    .AddPepperoni()
    .Build();
Console.WriteLine(burger.GetDescription());

LogSeperator();

//Abstract
AddTitle("Abstract:");

var woodenWindowFactory = new Abstract.WoodenWindowFactory();

var woodenWindow = woodenWindowFactory.MakeWindow();
var woodenWindowFittingExpert = woodenWindowFactory.MakeFittingExpert();

woodenWindow.GetDescription();
woodenWindowFittingExpert.GetDescription();


var ironWindowFactory = new Abstract.IronWindowFactory();

var ironWindow = ironWindowFactory.MakeWindow();
var ironWindowFittingExpert = ironWindowFactory.MakeFittingExpert();

ironWindow.GetDescription();
ironWindowFittingExpert.GetDescription();
LogSeperator();

#endregion

#region Structural

//Adapter
AddTitle("Adapter:");

Adapter.EuropeanSocket europeanSocket = new Adapter.EuropeanSocket();
Adapter.IPersianSocket persianSocket = new Adapter.SocketAdapter(europeanSocket);

Console.WriteLine("Client: Connecting Persian device to socket.");
persianSocket.Connect();

LogSeperator();

//Decorator
AddTitle("Decorator:");

Decorator.IPizza plainPizza = new Decorator.PlainPizza();
Decorator.IPizza cheesePizza = new Decorator.CheeseDecorator(plainPizza);
Decorator.IPizza tomatoPizza = new Decorator.TomatoDecorator(cheesePizza);

Console.WriteLine($"Plain Pizza: {plainPizza.GetDescription()}, Cost: {plainPizza.GetCost()}T");
Console.WriteLine($"Cheese Pizza: {cheesePizza.GetDescription()}, Cost: {cheesePizza.GetCost()}T");
Console.WriteLine($"Deluxe Pizza: {tomatoPizza.GetDescription()}, Cost: {tomatoPizza.GetCost()}T");

LogSeperator();

//Proxy
AddTitle("Proxy:");

Proxy.ISensitiveData adminData = new Proxy.SensitiveDataProxy("Admin");
Proxy.ISensitiveData regularUser = new Proxy.SensitiveDataProxy("User");

// Admin can access sensitive data, but regular user is denied
adminData.AccessData();
regularUser.AccessData();

LogSeperator();

//Facade
AddTitle("Facade:");

var facadeOperator = new Facade.FacadeOperator();
facadeOperator.PerformOperations();

LogSeperator();

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

LogSeperator();

//Strategy

AddTitle("Strategy:");

Strategy.ShoppingCart cart = new Strategy.ShoppingCart();

Strategy.IPaymentStrategy creditCardPayment = new Strategy.CreditCardPaymentStrategy("123456789");
Strategy.IPaymentStrategy paypalPayment = new Strategy.PayPalPaymentStrategy("user@gmail.com");

cart.SetPaymentStrategy(creditCardPayment);
cart.Checkout(50000);

cart.SetPaymentStrategy(paypalPayment);
cart.Checkout(80000);

LogSeperator();

//Chain Of Responsibility

AddTitle("Chain Of Responsibility:");

ChainOfResponsibility.IHelpDeskHandler helpDeskHandler = new ChainOfResponsibility.LevelOneSupport();

ChainOfResponsibility.HelpDeskTicket lowSeverityTicket =
    new ChainOfResponsibility.HelpDeskTicket(Severity: 1, Description: "Printer issue");
ChainOfResponsibility.HelpDeskTicket mediumSeverityTicket =
    new ChainOfResponsibility.HelpDeskTicket(Severity: 2, Description: "Software problem");
ChainOfResponsibility.HelpDeskTicket highSeverityTicket =
    new ChainOfResponsibility.HelpDeskTicket(Severity: 4, Description: "Server down");

helpDeskHandler.HandleTicket(lowSeverityTicket);
helpDeskHandler.HandleTicket(mediumSeverityTicket);
helpDeskHandler.HandleTicket(highSeverityTicket);

LogSeperator();

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

LogSeperator();

//Mediator

AddTitle("Mediator:");

Mediator.IAirTrafficControl atc = new Mediator.AirTrafficControl();

Mediator.IAircraft aircraft1 = new Mediator.Aircraft("Flight123", atc);
Mediator.IAircraft aircraft2 = new Mediator.Aircraft("Flight456", atc);
Mediator.IAircraft aircraft3 = new Mediator.Aircraft("Flight789", atc);

aircraft1.SendWarning("Traffic ahead.");
aircraft2.SendWarning("Turbulence reported.");
aircraft3.SendWarning("Hijack Warning.");

LogSeperator();

#endregion

#region Utils

Console.ReadLine();

void LogSeperator()
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