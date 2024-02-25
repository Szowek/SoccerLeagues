ENG

Soccer Leagues Application

Description:
The application enables you to check upon your desired league (currently only one) and its phases in a form of various tables. 
You can also check all matches that the team you choose played. Registred users have an additional functionality - they can add teams to their list of favourites.

Project steps: 
Main assignment -
1 - Installed NuGet packages such as EntityFramework, Sqlite
3 - Created ApplicationDbContext.cs responsible for getting DbSet objects from Models
4 - Initialised Models, mapped them via ApplicationDbContext
5 - Database connection&migration
6 - Created seeder responsible for sending data to database
7 - Created ViewModel (TeamStatisticsViewModel.cs) to transfer data from other models to the controller
8 - Written logic of controller, responsible for manipulating the data from ViewModel into desired form
9 - Printed data in Index.cshtml

Additional assignments steps -
1 - Installed NuGet package Web.CodeGenerator to generate blueprints for Identity files
2 - Decided to keep Identity database and League Soccer database separate, still using Sqlite
2 - Created Identity model and identity db context
3 - Disabled email confirmation as its not needed in app current state
4 - Created additional controller to manipulate data in accordance with first additional assignment(show all matches played by chosen team)
5 - Written JS script to help display the data fetched to the controller, also modified Index.cshtml to use these functionalities
6 - Created new model FavoriteTeam in order to help display needed data
7 - Created new controller file FavoriteTeamController and written the logic behind the task there
8 - Created new view responsible for showing the data from new controller and updated Index.cshtml to link it to the new logic
9 - Final code refactor

_____

PL

Opis:
Aplikacja pozwala sprawdzić wybraną ligę (obecnie tylko jedną) oraz jej fazy za pomocą wyświetlanych na stronie tabel.
Można również sprawdzić wszystkie mecze, w których grała wybrana drużyna. Zarejestrowani użytkownicy mają dodatkową funkcjonalność - dodawanie drużyn do swojej listy ulubionych.

Podejmowane przeze mnie kroki:
Główne zadanie -
1 - Zainstalowanie pakietów NuGet, takich jak EntityFramework, Sqlite
3 - Stworzenie ApplicationDbContext.cs odpowiedzialnego za pobieranie obiektów DbSet z modeli
4 - Inicjalizacja modeli, zmapowanie ich za pomocą ApplicationDbContext
5 - Połączenie z bazą danych i migracja
6 - Stworzenie seedera odpowiedzialnego za wysyłanie danych do bazy danych
7 - Stworzenie ViewModel (TeamStatisticsViewModel.cs) do przesyłania danych z innych modeli do kontrolera
8 - Napisanie logiki kontrolera, odpowiedzialnego za manipulowanie danymi z ViewModel na żądany kształt
9 - Wyświetlanie danych w Index.cshtml

Zadania dodatkowe -
1 - Zainstalowanie pakietu NuGet Web.CodeGenerator do generowania szablonów plików Identity, użycie AspNetCore.Identity
2 - Zdecydowałem się na oddzielenie bazy danych Identity i bazy danych Ligi Piłkarskiej, wciąż korzystam z Sqlite
2 - Stworzenie modelu Identity i kontekstu bazy danych Identity
3 - Wyłączenie potwierdzania adresu e-mail, ponieważ nie jest to potrzebne w obecnym stanie aplikacji, a ułatwia testowanie
4 - Stworzenie dodatkowego kontrolera do pobierania danych zgodnie z pierwszym dodatkowym zadaniem (pobranie wszystkich meczów rozegranych przez wybraną drużynę)
5 - Napisanie skryptu JS, aby umożliwić wyświetlanie danych wyselekcjonowanych przez kontroler i zmodyfikowanie Index.cshtml, aby korzystać z tych funkcjonalności
6 - Stworzenie nowego modelu FavoriteTeam w celu wyświetlenia potrzebnych danych
7 - Stworzenie nowego pliku kontrolera FavoriteTeamController i napisanie tam logiki związanej z zadaniem (m.in. dodawanie drużyn do listy ulubionych związanych z id użytkownika)
8 - Stworzenie nowego widoku odpowiedzialnego za wyświetlanie danych z nowego kontrolera i zaktualizowanie Index.cshtml, aby połączyć go z nową logiką
9 - Ogólny refactor kodu
