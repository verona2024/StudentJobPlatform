# StudentJobPlatform

## Përshkrimi

StudentJobPlatform është një aplikacion web i ndërtuar me ASP.NET Core që lidh studentët me punëdhënësit. Studentët mund të kërkojnë dhe aplikojnë për punë, ndërsa employer-at mund të publikojnë dhe menaxhojnë oferta pune.

Ky projekt është zhvilluar duke ndjekur ndarjen e qartë të përgjegjësive dhe parimet bazë të clean code.

## Funksionalitetet Kryesore

### Student
- Shikon listën e job-eve
- Kërkon dhe filtron job-et sipas fjalëve kyçe
- Aplikon për job
- Shikon aplikimet e veta
- Menaxhon profilin

### Employer
- Shton job-e të reja
- Editon dhe fshin job-et ekzistuese
- Shikon aplikimet për job-et e veta
- Ndryshon statusin e aplikimeve

### Admin
- Shikon përdoruesit
- Shikon job-et dhe aplikimet në sistem

## Arkitektura e Projektit

Projekti ndjek një strukturë të qartë me ndarje të përgjegjësive:

UI → Service → Repository

- **UI (Web Layer)** – ndërfaqja e përdoruesit në ASP.NET Core
- **Service Layer** – përmban logjikën e biznesit
- **Repository Layer** – menaxhon ruajtjen dhe marrjen e të dhënave

Kjo ndarje e bën projektin më të mirëmbajtshëm dhe më të lehtë për testim.

## Teknologjitë e Përdorura

- ASP.NET Core
- C#
- Repository Pattern
- MSTest
- JSON/CSV për ruajtjen e të dhënave

## Testimi

Projekti përmban unit tests për funksionalitetet kryesore, si:
- aplikimi në job
- aplikimi i dyfishtë
- validimi për student ID jo valid
- validimi për job ID jo valid
- trajtimi i rastit kur job nuk ekziston

## Error Handling dhe Validation

- Përdoren `try-catch` në service layer
- Janë shtuar kontrolle për ID jo valide
- Sistemi kontrollon nëse job ekziston para aplikimit
- Parandalohet aplikimi i dyfishtë
- Përdoren mesazhe të qarta për raste gabimi

## Logging

- Është implementuar `Logger`
- Gabimet ruhen në file (`logs.txt`)
- Logging ndihmon në debug dhe mirëmbajtje

## Përmirësimet në Improvement Sprint

Në këtë sprint janë realizuar këto përmirësime:
- refaktorim i validimeve të përsëritura me `ValidationHelper`
- përmirësim i validation dhe error handling në `ApplicationService`
- shtim i testeve për raste kufitare
- përmirësim i dokumentimit me `project-audit.md` dhe `improvement-report.md`

## Si të Ekzekutohet Projekti

1. Hap `StudentJobPlatform.sln` në Visual Studio
2. Vendos `StudentJobPlatform.Web` si startup project
3. Kliko Run (`F5`)
4. Aplikacioni hapet në browser

## Përmirësime të Mundshme në të Ardhmen

- Migrimi nga ruajtja aktuale në databazë reale (p.sh. PostgreSQL)
- Validime më të avancuara
- Siguri më e fortë për të dhënat e përdoruesit
- Zgjerim i testimit me më shumë edge cases

## Autori

Verona Ademaj