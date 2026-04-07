# Sprint 2 Report — Verona Ademaj

## Çka Përfundova

Gjatë këtij sprinti kam arritur të përfundoj dhe përmirësoj në mënyrë të konsiderueshme projektin tim duke implementuar funksionalitete të reja, duke refaktorizuar kodin dhe duke shtuar testim.

### Feature e Re

Kam implementuar sistemin e sortimit të job-eve (Sorting System), i cili i lejon përdoruesit të:

- Sortojë job-et sipas titullit (A-Z)
- Sortojë sipas pagës (nga më e vogla në më të madhen)
- Sortojë sipas pagës (nga më e madhja në më të voglen)

Ky funksionalitet është implementuar duke respektuar arkitekturën:

- UI → merr input nga përdoruesi
- Service (JobService) → përmban logjikën e sortimit
- Repository → përdoret vetëm për marrjen e të dhënave

---

### Përmirësime në Kod (Clean Code & Refactoring)

- Kam ndarë logjikën në shtresa të qarta: UI → Service → Repository
- Kam reduktuar përsëritjen e kodit
- Kam përdorur metoda helper për validim dhe kontroll
- Kam krijuar `Constants.cs` për role dhe status (Student, Employer, Admin)
- Kam organizuar kodin në mënyrë më të lexueshme dhe të mirëmbajtshme

---

### Error Handling

Kam implementuar trajtim të gabimeve në të gjitha pjesët kryesore të sistemit:

- Kontroll për input të pavlefshëm (string bosh, ID <= 0, etj.)
- try-catch në Service dhe Repository për të parandaluar crash
- Mesazhe të qarta për userin në rast gabimi
- Kontroll për raste si:
  - aplikim i dyfishtë në të njëjtin job
  - job që nuk ekziston
  - input i gabuar nga useri

Programi nuk crashon në asnjë rast dhe vazhdon ekzekutimin normal.

---

### Logging

Kam implementuar një sistem logging për gabime:

- `Logger.cs` ruan gabimet në file `logs.txt`
- Çdo exception ruhet për debug dhe analizë
- Kjo ndihmon në mirëmbajtjen dhe stabilitetin e sistemit

---

### Role-Based Access Control

Kam implementuar kontroll të roleve:

- Student → vetëm shikon dhe aplikon
- Employer → menaxhon vetëm job-et e veta
- Admin → ka akses në të gjitha të dhënat

Përdoruesit nuk mund të aksesojnë funksionalitete që nuk u përkasin.

---

### Unit Testing

Kam krijuar një projekt testimi dhe kam implementuar unit tests për funksionalitetet kryesore:

- Test për shtimin e job-it
- Test për sortimin sipas pagës
- Test për filtrimin sipas lokacionit
- Test për aplikimin në job
- Test për kontrollin e aplikimit të dyfishtë

Të gjitha testet kalojnë me sukses (Passed).

---

## ❗ Çka Nuk U Përfundua

- Projekti aktualisht përdor CSV për ruajtjen e të dhënave dhe jo databazë reale
- Nuk është implementuar ende PostgreSQL ose një databazë tjetër.

Këto janë planifikuar si përmirësime për fazat e ardhshme të projektit.

---

## 🔜 Planet për Vazhdim

Në vazhdim planifikoj:

- Migrimin nga CSV në databazë reale (PostgreSQL)
- Implementimin e hashing për password (siguri më e lartë)
- Validime më të avancuara (email unik, format valid, etj.)
- Përmirësim të UI (kalim në ASP.NET Core web app)
- Shtim të integration tests

---

## 📚 Çka Mësova

Gjatë këtij sprinti kam mësuar:

- Si të organizoj një projekt me arkitekturë të ndarë në shtresa
- Rëndësinë e clean code dhe refactoring
- Si të implementoj error handling për stabilitet
- Si të krijoj dhe ekzekutoj unit tests në .NET
- Si të strukturoj një projekt për mirëmbajtje dhe zgjerim në të ardhmen.
