using DesignPattern.Creational;

//Singleton
var instance = Singleton.GetInstance();
Console.WriteLine($"Singleton : {instance.GetHashCode().ToString()}");

//Simple Factory
var desk = SimpleFactory.DeskFactory.MakeDesk(80, 30, 40);
Console.WriteLine(
    $"SimpleFactory : woodenDesk height: {desk.GetHeight()} - width: {desk.GetWidth()} - length: {desk.GetLength()}");

//Factory Method
var woodenChairSeller = new FactoryMethod.WoodenChairSeller();
woodenChairSeller.SellChair();

var metalChairSeller = new FactoryMethod.MetalChairSeller();
metalChairSeller.SellChair();

//Builder
var burger = new Builder.BurgerBuilder(15)
    .AddCheese()
    .AddLettuce()
    .AddPepperoni()
    .Build();
Console.WriteLine($"{burger.GetDescription()}");

//Abstract
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