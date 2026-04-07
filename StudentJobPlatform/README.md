# StudentJobPlatform

## Përshkrimi

StudentJobPlatform është një aplikacion web i ndërtuar me ASP.NET Core që mundëson lidhjen ndërmjet studentëve dhe punëdhënësve. Platforma lejon studentët të kërkojnë dhe aplikojnë për punë, ndërsa employer-at mund të publikojnë dhe menaxhojnë ofertat e punës.

Ky projekt është zhvilluar duke ndjekur parimet e arkitekturës së pastër dhe clean code.

---

## Funksionalitetet Kryesore

### 👨‍🎓 Student
- Shikon listën e job-eve
- Kërkon dhe filtron job-et sipas fjalëve kyçe
- Aplikon për job
- Shikon aplikimet e veta
- Menaxhon profilin (major, skills, availability)
- Merr rekomandime të job-eve

### 🧑‍💼 Employer
- Shton job-e të reja
- Editon dhe fshin job-et ekzistuese
- Shikon aplikimet për job-et e veta
- Ndryshon statusin e aplikimeve (Accepted / Rejected)

### 👑 Admin
- Shikon të gjithë përdoruesit
- Shikon job-et dhe aplikimet në sistem

---

## Arkitektura e Projektit

Projekti ndjek një strukturë të qartë me ndarje të përgjegjësive:

UI → Service → Repository

- **UI (Web Layer)** – ndërfaqja e përdoruesit (ASP.NET Core)
- **Service Layer** – përmban logjikën e biznesit
- **Repository Layer** – menaxhon të dhënat (CRUD operations)

Kjo ndarje e bën projektin më të mirëmbajtshëm dhe të zgjerueshëm.

---

## Teknologjitë e Përdorura

- ASP.NET Core
- C#
- Repository Pattern
- MSTest (Unit Testing)
- JSON/CSV për ruajtjen e të dhënave

---

## Testimi

Projekti përmban unit tests për funksionalitetet kryesore:

- Shtimi i job-eve
- Filtrimi dhe kërkimi i job-eve
- Sortimi i job-eve sipas pagës
- Aplikimi në job
- Kontrolli për aplikim të dyfishtë

Të gjitha testet janë ekzekutuar me sukses (Passed).

---

## Error Handling

- Përdoren `try-catch` në Service dhe Repository
- Validim i inputeve për të parandaluar gabime
- Mesazhe të qarta për përdoruesin
- Sistemi nuk crashon gjatë ekzekutimit

---

## Logging

- Është implementuar `Logger`
- Gabimet ruhen në file (`logs.txt`)
- Ndihmon në debug dhe mirëmbajtje

---

## Si të Ekzekutohet Projekti

1. Hap projektin në Visual Studio
2. Vendos `StudentJobPlatform.Web` si startup project
3. Kliko Run (F5)
4. Aplikacioni hapet në browser

---

## Përmirësime të Mundshme

- Migrimi nga CSV në databazë reale (p.sh. PostgreSQL)
- Implementimi i hashing për password
- Validime më të avancuara (email unik, etj.)
- UI më i avancuar

---

## Autori

Verona Ademaj
