# Project Audit — StudentJobPlatform

## 1. Përshkrimi i shkurtër i projektit

StudentJobPlatform është një aplikacion web i ndërtuar me ASP.NET Core që lidh studentët me punëdhënësit. Sistemi u mundëson studentëve të shohin oferta pune, të filtrojnë dhe të aplikojnë për to, ndërsa employer-at mund të krijojnë, përditësojnë dhe fshijnë oferta pune dhe të menaxhojnë aplikimet.

Përdoruesit kryesorë të sistemit janë:
- Student
- Employer
- Admin

Funksionaliteti kryesor i sistemit është:
- menaxhimi i job-eve
- aplikimi në job
- kontrolli i aplikimeve
- organizimi i logjikës në shtresa të ndara

## 2. Çka funksionon mirë?

1. Projekti ka ndarje të qartë në shtresa: Web/UI, Service dhe Repository.
2. Funksionalitetet bazë si aplikimi në job, menaxhimi i job-eve dhe kontrolli i roleve funksionojnë.
3. Ekzistojnë unit tests për disa raste të rëndësishme.
4. Projekti ka dokumentim bazik dhe strukturë të lexueshme.
5. Ka përdorim të logging dhe trajtim bazik të gabimeve.

## 3. Dobësitë e projektit

1. Validimi i inputeve nuk ishte i centralizuar dhe përsëritej në disa metoda.
2. Error handling ekzistonte, por nuk ishte i unifikuar në të gjitha rastet.
3. Testet fillestare mbulonin vetëm disa raste bazike dhe jo mjaftueshëm edge cases.
4. Dokumentimi fillestar nuk e shpjegonte mjaftueshëm improvement sprint dhe ndryshimet e bëra.
5. Projekti përdor JSON/CSV në vend të databazës reale, gjë që e kufizon shkallëzimin.
6. Siguria bazike mund të përmirësohet më tej, sidomos te validimi dhe ruajtja e të dhënave.
7. Disa pjesë të kodit mund të bëhen më të pastra për mirëmbajtje afatgjatë.

## 4. 3 përmirësime që do t’i implementoj

### Përmirësimi 1 — Refaktorim i validimeve
- **Problemi:** Në `ApplicationService` kontrolli për ID jo valide përsëritej në disa metoda.
- **Zgjidhja:** U krijua `ValidationHelper` për të centralizuar validimet bazike.
- **Pse ka rëndësi:** E bën kodin më të pastër, më të lexueshëm dhe më të mirëmbajtshëm.

### Përmirësimi 2 — Përmirësim i reliability / validation / error handling
- **Problemi:** Sistemi nuk trajtonte në mënyrë mjaftueshëm të qartë disa raste si job që nuk ekziston ose input jo valid.
- **Zgjidhja:** U përmirësua `ApplicationService` për të kontrolluar:
  - student ID jo valid
  - job ID jo valid
  - job që nuk ekziston
  - aplikim të dyfishtë
  - status jo valid në përditësimin e aplikimit
- **Pse ka rëndësi:** Sistemi bëhet më i qëndrueshëm dhe jep feedback më të qartë për përdoruesin.

### Përmirësimi 3 — Përmirësim i dokumentimit dhe testimit
- **Problemi:** Dokumentimi nuk ishte i plotë dhe testet nuk mbulonin mjaftueshëm raste kufitare.
- **Zgjidhja:** U përditësua `README.md`, u shtuan `project-audit.md` dhe `improvement-report.md`, dhe u shtuan teste të reja për raste jo valide.
- **Pse ka rëndësi:** E bën projektin më të kuptueshëm, më profesional dhe më të besueshëm.

## 5. Një pjesë që ende nuk e kuptoj plotësisht

Një pjesë që ende dua ta kuptoj më mirë është organizimi i një sistemi më të avancuar me databazë reale, sidomos si menaxhohen migrimet, ruajtja e të dhënave dhe autorizimi në një aplikacion më të madh.

Gjithashtu dua të kuptoj më thellë si të organizohet testimi përtej unit tests, për shembull me integration tests për flow-t kryesore.