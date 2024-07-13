"# projekt_koncowy_CodersLab_backend" 


# RachunkiTechniczneApp

## Opis projektu

Celem tego projektu jest ułatwienie weryfikacji zbioru bankowych rachunków technicznych oraz weryfikacji poprawności sald.

Całość składa się z dwóch modułów: moduł rejestru oraz moduł raportowy. W module rejestrowym można wyświetlić wszystkie zgromadzone rachunki techniczne. Użytkownik typu "Admin" może wyświetlić wszystkie rachunki. Wyświetlone dane może przefiltrować, tak by ograniczyć wyniki. Ma dostępne funkcje CRUD dla encji "Kontrakty" i "Wlasciciele".
Użytkownik typu "User" może tylko wyświetlić rachunki przypisane do swojego konta.
W module raportowym użytkownik "Admin" widzi wszystkie rachunki wraz z saldami księgowymi oraz informacją, czy pozostali użytkownicy typu "User" już potwierdzili salda. Użytkownicy typu "User" będą widzieć tylko kontrakty przypisane do ich konta i dodatkowo salda dla tych kontraktów. Poza tym będą mieli możliwość potwierdzenia czy wyświetlone saldo jest zgodne z saldem AFT (zewnętrzny program), czy operacje w AFT są prawidłowe i pole do wprowadzenia uwag.

Dzięki temu projektowi proces potwierdzania sald rachunków technicznych zostanie zautomatyzowany i ułatwiony dla wszystkich uczestników. Dodatkowo zwiększy bezpieczeństo, ponieważ usprawnienie procesu kontroli pozytywnie wpłynie na zmniejszenie zagrożeń z tytułów fraudów pracowniczych.

## Krótki wstęp techniczny

Strona backendowa będzie zbudowana w języku C# wraz z wykorzystanie frameworka .NET Core 6, będzie ona powstawała na bazie architektury n-warstwowej. Jej głównym założeniem jest utworzenie REST API, które będzie wykorzystywane przez frontend.
Całość powinna być zabezpieczona autoryzacją JWT, w celu zabezpieczenia dostępu do danych dla osób niepowołanych.

Frontend natomiast będzie zbudowany przy pomocy Java Script wraz z frameworkiem React. Komunikacja będzie odbywała się po REST API, jej głównym założeniem jest wysyłanie, odbieranie oraz wizualizacja informacji pobranych z backendu, w celu zapewnienia uproszczonego użytkowania dla użytkownika końcowego. Ze względów czasowych priorytet w niej nie będzie kładziony na UI oraz UX, a na samą funkcjonalność.

Cały projekt ma być w swoich założeniach Proof of Concept, który mógłby być podstawą do wdrożenia takowego rozwiązania, dlatego też dane oraz schemat bazy danych są uproszczone.

## Przewidziane zadania (MoSCoW + Story Points)

### Must

**[BACKEND] Stworzenie bazy danych**
- Koszt: **M**
- DoD:
-- Stworzenie bazy
-- Stworzenie tabel
-- Wpisanie danych podglądowych

**[BACKEND] Przygotowanie szkieletu aplikacji**
Koszt: **XL**
DoD:
- Stworzenie serwisów
- Stworzenie repozytoriów
- Stworzenie modeli
- Stworzenie kontrolerów
- Stworzenie interfejsów

**[BACKEND] Połączenie z bazą danych**
Koszt: **S**
DoD:
- Zainstalowanie Dappera
- Stworzenie klasy i interfejsu DapperContext

**[BACKEND] Zaimplementowanie funkcji CRUD dla encji Kontrakty**
Koszt: **L**
DoD:
- Stworzenie repozytorium
- Stworzenie kontrolera
- Stworzenie serwisu

**[BACKEND] Zaimplementowanie funkcji CRUD dla encji Właściciele**
Koszt: **L**
DoD:
- Stworzenie repozytorium
- Stworzenie kontrolera
- Stworzenie serwisu

**[BACKEND] Logowanie**
Koszt: **L**
DoD:
- Autoryzacja przy pomocy JWT

**[FRONTEND] Logowanie**
Koszt: **L**
Dod:
- Wyświetlenie danych dla właściwego użytkownika

**[FRONTEND] Stworzenie ekranu logowania**
Koszt: **M**
DoD:
- Wyświetlenie formularza logowania

**[FRONTEND] Stworzenie ekranu wyboru modułu**
Koszt: **M**
DoD:
- Wyświetlenie panelu opcji dla użytkownika

**[FRONTEND] Stworzenie ekranu modułu rejestrowego**
Koszt: **L**
DoD:
- Stworzenie osobnych ekranów z danymi dla Admina
- Stworzenie buttonów dla Admina do filtrowania danych
- Stworzenie buttonów dla Admina do CRUD

**[FRONTEND] Stworzenie ekranu modułu raportowego**
Koszt: **L**
DoD:
- Stworzenie osobnych ekranów z danymi dla Admina i Usera
- Stworzenie buttonów dla Admina do filtrowania danych
- Stworzenie buttonów dla Admina do CRUD
- Stworzenie edytowalnych pól do wypełnienia dla Usera

**[FRONTEND] Podpięcie funkcji CRUD pod buttony na ekranach**
Koszt: **L**
DoD:
- Wszystkie stworzone buttony są podpięte

**[FRONTEND] Pełna komunikacja między backendem a frontendem**
Koszt: **L**
DoD:
- Dane między backendem a frontendem są wyświetlane

### Should

**[FRONTEND] Komunikaty błędów o niezalogowaniu użytkownika**
Koszt: **M**
DoD:
- Wyświetlanie czytelnych dla użytkownika opisów błędów

**[BACKEND] Utworzenie middleware**
Koszt: **S**
DoD:
- Zainstalowanie i skonfigurowanie Swaggera

### Could

- **Utworzenie testów dla backendu**
- **Utworzenie testów dla frontendu**
- **Zapisania wyświetlonych danych do plików w wybranym przez użytkownika formacie**
- **Zgłaszanie przez formularz nowych rachunków przez Usera, do akceptacji Admina**

### Wish

- **Połączenie z bazą danych modułu AFT, by porównać salda inwentury i modułowe**
- **Wpięcie się do AFT by móc otwierać rachunki lub zbierać informacje o otwartych rachunkach na danych produktach**
- **Logowanie Microsoft Authenticator**






