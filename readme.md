Begin met een console applicatie

Ex1

    Toon uitkomst van 4*3

    Commit

---
Ex2

    vervang de 4 en 3 door variables

    Commit

---
Ex3

    Business Logic Multiply in een methode gestoken

    Commit

---
Ex4

    Refactor:
    Zorg dat enkel de input (values, operator) en startup in de main staan.
    - je hebt een start-method of dowork-method die de parameters bevat en die dan de applicatie uitvoert
    - Zorg ervoor dat de switch gecontained is. Een Switch = Smell naar factory.

    Commit

---
Ex5

    Refactor: fix - build

    Commit

---
Ex6

    Refactor: next step: Weg van statics!
    Code is for production.
    Ik wil twee instanties om te rekenen. Eén voor 4+3 en één voor 4*3
    De beide instanties moeten kunnen displayen naar de console op dezelfde manier.
    Zorg dat je weet welk resultaat komt van welke calculator

    Commit

---
Ex7

    Installeer NUnit nugetpackage met de NUnitTestadapter
    
    Schrijf een test voor de calculator dat 4*3=12 en dat 4*3 niet gelijk is aan 7
    
    Schrijf een test voor de calculator dat 4+3=7 en dat 4+3 niet gelijk is aan 12
    Schrijf een test zodat je zeker weet dat de calculator wordt aangeroepen wordt.
        Is dit mogelijk?
    
    Refactor de code zodat je alles kan testen.
        Je moet kunnen vragen aan een Startup-class of de methode Calculate werd opgeroepen
        Je moeten kunnen vragen aan een Startup-class of de methode Display werd opgeroepen
            Doordenker:
                Hoe herschrijf je de code van de ConsoleDisplayer dat je kunt testen wat er wordt getoond?
                ConsoleAdapter schrijven, of werken met DuckTyping of kijken bij Nuget of er al zo'n adapter bestaat met interfacing...
    
    Opkuis, verschillende bestanden maken => 't wordt te groot.

    Commit

---
Ex8

    Oefening op Single Responsability gecombineerd met Manuele Injection
    Indien nog niet gedaan bij het vorige voorbeeld, zorg ervoor dat de Displayer ook getest worden wat hij zal displayen.
    Schrijf nu een test waarvan je het resultaat en niet of de methode gecalled wordt gaat testen.
    Schrijf dan een test zodat je zeker bent dat de console methode e.g. WriteLine wordt opgeroepen met wat hij moet tonen.

    Run tests

    Commit

---
Ex10 - Ex11

    Verwijderen van oude referentie Unity (foutje bij setup by me).
    Toevoegen van unity op project DI Calculator
    Splits het gebruik van de container op in twee delen:
        -Registraties
        -Resolving
        Gebruik die twee zaken nooit door elkaar.
        Werk altijld met een child container
            In een childcontainer kan je ook je registraties overschrijven.
    Vervang de manuele injectie door een resolve op de container.
    
    Registreer nog niet 1 interface met de gekozen implementatie.
    
    Run

    Welke foutmelding krijg je?

    Commit

---
Ex12

    Fix zodat de applicatie runt via de registraties
    Run

    Commit

---
Ex13

    We gaan de Open/Closed principe toepassen van SOLID in de OpenForExtensionCalculator
    De switch gaat naar een Factory (where it belongs!!)
    We gaan werken via een OpenForExtensionCalculator die de interface ICalculator implementeert.
    De oude registratie doen we eruit, en we registreren de nieuwe calculator.

    Run

    Commit

Ex14

---
    
    We gaan aan de advanced calculator de subtraction and the division operation toevoegen
    Kuis de openforextension calculator op (dead code...) van de vorige commit
    Voer twee extra berekeningen uit, namelijk 4-3 en 3/4
    We ondersteunen geen restberekeningen.

    Run

    Commit

---
Ex15

    We willen werken met een featureFlag. Aan de hand van een setting:
    Bijv.  V0, V1 gaan we bepalen welke calculator we gaan laden.

    Test als je V0 gebruikt, bij het runnen van de applicatie, 
        je een argument exception krijgt bij het gebruik van de - en de /

    Run V0, V1

    Commit

---
Ex16

    We maken een V2 van de OpenForExtensionCalculator.
    In plaats van  te werken met de OperationFactory, gaan we nu alle Operations injecteren en gaan zoeken op basis van de naam.
        Zouden we niet evengoed een OperationFactoryV2 kunnen gemaakt hebben in plaats van een nieuwe calculator?
        
        Open for discussion

    Run V2

    Commit

---
Ex17

    Vorige oefening werkt niet. De IOperations zijn niet geregistreerd!
        Fix: de naam van één de operations.
        Hoe konden we dit tegengaan ? 
        
            => Unittesting Testing
            => Container.builduptree            
    
    Verander het gebruik van de OperationFactory, ook door de Defines te gebruiken (propere code...))

    Run

    Commit

---
Ex18

    Refactor de register methode, zodanig dat die versie onafhankelijk zijn.
        Nadeel van deze methode is wel dat je de childcontainer moet bewerken en je niet on the fly kunt switchen van functionaliteit.
        Maar soms hoeft dat ook niet....
        
        Zorg ervoor dat gebruiker een bericht krijgt van geen ondersteuning van niet ondersteunde operands

    Run

    Commit

---
Ex19

    De registraties worden te groot en uitgebreid. Zorg er voor dat per management folder een registratie class is, 
        die je kan oproepen vanaf de main.


    Run

    Commit

---
Ex20

    Maak een V3 calculation, maar gebruik named resolving en gebruik de container daarvoor in een wrapper. Zodat je niet aan alle functionaliteit kan,
    zo wordt het ook zichtbaar dat je named resolving wilt toepassen.

    Run

    Commit

---
Ex21

    Maak gebruik van een KeyInputMapper, zodat je niet meer gebonden bent
        aan de * maar zodat je ook een x kan gebruiken of een . voor de multiply

    Run

    Commit

---
Ex22

    Zorg dat je de CurrentUser  capteert of een random naam toewijst bij de start van de applicatie en registreer de instantie.

    Maak dat je de usernaam kan displayen bij de displayer.
    
    Fix all the tests
        Discussie: hoe kunnen we dit sneller opmerken?

    Run

    Commit

---
Ex23

    Install Nuget package Unity Interception
    Maak gebruik van de pre en post methodes, zodanig je naar de console kan wegschrijven wanneer je in een methode komt en wanneer ze klaar is.
    
    Je kan ook zaken gaan cachen... https://msdn.microsoft.com/en-us/library/dn178466(v=pandp.30).aspx

    Run

    Verander het . bij de operand naar een $. Dat ondersteunen we niet. Wat wordt er geoutput?

    Commit
