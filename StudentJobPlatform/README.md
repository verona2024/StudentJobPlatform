# Student Job Platform

## Përshkrimi i Projektit
Student Job Platform është një aplikacion i ndërtuar në C# (Console Application) që synon të menaxhojë dhe të lehtësojë procesin e gjetjes dhe aplikimit për punë part-time nga studentët. Ky sistem simulon një platformë reale ku studentët mund të eksplorojnë mundësi pune, ndërsa punëdhënësit publikojnë oferta dhe admini mbikëqyr funksionimin e sistemit.

Qëllimi kryesor i këtij projekti është ndërtimi i një sistemi të strukturuar mirë, duke përdorur parimet bazë të arkitekturës së softuerit dhe programimit të orientuar në objekte (OOP). Projekti fokusohet në ndarjen e përgjegjësive, modularitetin, dhe ndërtimin e një kodi të pastër dhe të mirëorganizuar.

---

## Funksionalitetet Kryesore
Sistemi ofron funksionalitete bazë për menaxhimin e një platforme punësimi:

- Shfaqja e listës së punëve të disponueshme
- Aplikimi i studentëve në punë të caktuara
- Menaxhimi i përdoruesve (Student, Employer, Admin)
- Kontrolli i statusit të aplikimeve
- Ndërveprim i thjeshtë përmes një menuje në console

Edhe pse aplikacioni është i thjeshtë, ai është ndërtuar në mënyrë që të mund të zgjerohet lehtësisht në të ardhmen.

---

## Arkitektura e Projektit
Projekti ndjek një **arkitekturë të ndarë në shtresa (Layered Architecture)** për të siguruar organizim të mirë dhe mirëmbajtje të lehtë.

### 1. Models (Shtresa e të dhënave)
Kjo shtresë përmban klasat që përfaqësojnë entitetet kryesore të sistemit:

- `User` – klasa bazë për përdoruesit
- `Student` – trashëgon nga User dhe përmban të dhëna shtesë
- `Employer` – përfaqëson punëdhënësin
- `Job` – përfaqëson një ofertë pune
- `Application` – lidh studentin me një punë

Këto klasa përdorin enkapsulim (private fields + public properties) për të mbrojtur të dhënat.

---

### 2. Services (Logjika e biznesit)
Kjo shtresë përmban logjikën kryesore të sistemit:

- `AuthService` – menaxhon autentikimin e përdoruesve
- `JobService` – menaxhon punët (shtim, kërkim, listim)
- `ApplicationService` – menaxhon aplikimet në punë

Kjo ndarje bën që logjika të mos përzihet me UI ose me ruajtjen e të dhënave.

---

### 3. Data (Qasja në të dhëna)
Kjo shtresë implementon **Repository Pattern**:

- `IRepository<T>` – interface që definon operacionet:
  - GetAll()
  - GetById()
  - Add()
  - Save()

- `FileRepository<T>` – implementimi konkret i repository

Ky model e ndan logjikën e të dhënave nga pjesa tjetër e aplikacionit dhe e bën sistemin më fleksibil për ndryshime në të ardhmen.

---

### 4. UI (Ndërfaqja me përdoruesin)
Kjo shtresë menaxhon ndërveprimin me përdoruesin përmes console:

- `MenuManager` – shfaq menunë dhe merr input nga përdoruesi

Menuja është e implementuar me loop (`while`) në mënyrë që përdoruesi të mund të vazhdojë përdorimin e aplikacionit pa u mbyllur.

---

### 5. Program.cs (Entry Point)
`Program.cs` është pika hyrëse e aplikacionit dhe ka vetëm përgjegjësi inicializimi:

- krijon repository-t
- krijon services
- nis UI (MenuManager)

Ky minimalizim i `Program.cs` është praktikë e mirë në arkitekturë.

---

## Parimet e përdorura
Ky projekt demonstron disa koncepte të rëndësishme:

- **Encapsulation** – përdorimi i private fields dhe public methods
- **Inheritance** – Student dhe Employer trashëgojnë nga User
- **Separation of Concerns** – ndarja në Models, Services, Data, UI
- **Repository Pattern** – ndarja e qasjes në të dhëna nga logjika
- **Modulariteti** – çdo pjesë ka rol të veçantë

---

## Struktura e Projektit

```
StudentJobPlatform/
├── Models/
├── Services/
├── Data/
├── UI/
├── docs/
├── Program.cs
├── README.md
└── .gitignore
```


---

## Mundësi për zgjerim
Ky projekt është ndërtuar në mënyrë që të zgjerohet lehtë në të ardhmen:

- Ruajtje reale në file ose database
- Filtrimi i punëve sipas kategorisë
- Role të ndara me menu të ndryshme
- Ndërtimi i një GUI ose web versioni
- Autentikim më i avancuar

---

## Përfundim
Student Job Platform është një shembull i qartë i aplikimit të parimeve të arkitekturës së softuerit në një projekt praktik. Struktura e ndarë, përdorimi i repository pattern dhe organizimi i mirë i kodit e bëjnë këtë projekt të lehtë për t’u kuptuar, përdorur dhe zgjeruar.

---

## Si të ekzekutohet projekti

1. Hape projektin në Visual Studio
2. Sigurohu që projekti është vendosur si Startup Project
3. Kliko Run (Start)
4. Ndiq menunë në console:
   - 1 → shfaq punët
   - 2 → apliko në punë
   - 0 → dil nga aplikacioni