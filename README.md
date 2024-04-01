ENG<br>
<br>
Soccer Leagues Application<br>
<br>
Description:
The application enables you to check upon your desired league (currently only one) and its phases in a form of various tables.<br> 
You can also check all matches that the team you choose played. Registred users have an additional functionality - they can add teams to their list of favourites.<br>
<br>
Project steps:<br>
Main steps -<br>
1 - Decided to use EntityFramework, Sqlite<br>
3 - Created ApplicationDbContext.cs responsible for getting DbSet objects from Models<br>
4 - Initialised Models, mapped them via ApplicationDbContext<br>
5 - Database connection&migration<br>
6 - Created seeder responsible for sending data to database<br>
7 - Created ViewModel (TeamStatisticsViewModel.cs) to transfer data from other models to the controller<br>
8 - Written logic of controller, responsible for manipulating the data from ViewModel into desired form<br>
9 - Printed data in Index.cshtml<br>
<br>
Additional features steps -<br>
1 - Decided to use Web.CodeGenerator to generate blueprints for Identity files<br>
2 - Decided to keep Identity database and League Soccer database separate, still using Sqlite<br>
2 - Created Identity model and identity db context<br>
3 - Disabled email confirmation as its not needed in app current state<br>
4 - Created additional controller to manipulate data in accordance with first additional assignment(show all matches played by chosen team)<br>
5 - Written JS script to help display the data fetched to the controller, also modified Index.cshtml to use these functionalities<br>
6 - Created new model FavoriteTeam in order to help display needed data<br>
7 - Created new controller file FavoriteTeamController and written the logic behind the task there<br>
8 - Created new view responsible for showing the data from new controller and updated Index.cshtml to link it to the new logic<br>
9 - Final code refactor<br>
<br>
_____<br>
<br>
PL<br>
<br>
Opis:<br>
Aplikacja pozwala sprawdzić wybraną ligę (obecnie tylko jedną) oraz jej fazy za pomocą wyświetlanych na stronie tabel.<br>
Można również sprawdzić wszystkie mecze, w których grała wybrana drużyna. Zarejestrowani użytkownicy mają dodatkową funkcjonalność - dodawanie drużyn do swojej listy ulubionych.<br>
<br>
Podejmowane przeze mnie kroki:<br>
Główne funkcjonalności -<br>
1 - Decyzja o użyciu EntityFramework, Sqlite<br>
3 - Stworzenie ApplicationDbContext.cs odpowiedzialnego za pobieranie obiektów DbSet z modeli<br>
4 - Inicjalizacja modeli, zmapowanie ich za pomocą ApplicationDbContext<br>
5 - Połączenie z bazą danych i migracja<br>
6 - Stworzenie seedera odpowiedzialnego za wysyłanie danych do bazy danych<br>
7 - Stworzenie ViewModel (TeamStatisticsViewModel.cs) do przesyłania danych z innych modeli do kontrolera<br>
8 - Napisanie logiki kontrolera, odpowiedzialnego za manipulowanie danymi z ViewModel na żądany kształt<br>
9 - Wyświetlanie danych w Index.cshtml<br>
<br>
Dodatkowe funkcjonalności -<br>
1 - Decyzja o użyciu Web.CodeGenerator do generowania szablonów plików Identity, użycie AspNetCore.Identity<br>
2 - Zdecydowałem się na oddzielenie bazy danych Identity i bazy danych Ligi Piłkarskiej, wciąż korzystam z Sqlite<br>
2 - Stworzenie modelu Identity i kontekstu bazy danych Identity<br>
3 - Wyłączenie potwierdzania adresu e-mail, ponieważ nie jest to potrzebne w obecnym stanie aplikacji, a ułatwia testowanie<br>
4 - Stworzenie dodatkowego kontrolera do pobierania danych zgodnie z pierwszym dodatkowym zadaniem (pobranie wszystkich meczów rozegranych przez wybraną drużynę)<br>
5 - Napisanie skryptu JS, aby umożliwić wyświetlanie danych wyselekcjonowanych przez kontroler i zmodyfikowanie Index.cshtml, aby korzystać z tych funkcjonalności<br>
6 - Stworzenie nowego modelu FavoriteTeam w celu wyświetlenia potrzebnych danych<br>
7 - Stworzenie nowego pliku kontrolera FavoriteTeamController i napisanie tam logiki związanej z zadaniem (m.in. dodawanie drużyn do listy ulubionych związanych z id użytkownika)<br>
8 - Stworzenie nowego widoku odpowiedzialnego za wyświetlanie danych z nowego kontrolera i zaktualizowanie Index.cshtml, aby połączyć go z nową logiką<br>
9 - Ogólny refactor kodu<br>
<br>
<br>
<br>
Co można dodać - możliwość zmiany ligi, panel administratora, panel użytkownika i funkcjonalności dodawania własnych lig (drużyn, meczy i faz ligowych), rozwinięcie funkcjonalności ulubinych drużyn (np. zaznaczenie na tabelach ligowych ich rekordy)
<br>
<br>
Ogólny zarys najważniejszych tabeli i ich relacji<br>
![SoccerLeague_Tables](https://github.com/Szowek/SoccerLeagues/assets/67469783/94dd9487-ecc4-4512-bf10-06b94b22225f)

