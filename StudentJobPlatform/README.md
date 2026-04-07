# StudentJobPlatform

## Përshkrimi
StudentJobPlatform është një aplikacion web i ndërtuar me ASP.NET Core që lejon studentët të kërkojnë dhe aplikojnë për punë, ndërsa employer-at mund të menaxhojnë job-et dhe aplikimet.

---

## Funksionalitetet

### Student
- Shikon listën e job-eve
- Kërkon dhe filtron job-et
- Aplikon për job
- Shikon aplikimet e veta
- Menaxhon profilin

### Employer
- Shton job-e
- Editon dhe fshin job-e
- Shikon aplikimet
- Ndryshon statusin e aplikimeve

### Admin
- Shikon të gjithë user-at
- Shikon job-et dhe aplikimet

---

## Arkitektura

Projekti është ndërtuar me arkitekturë:

UI → Service → Repository

- UI (Web) – ndërfaqja për përdoruesin
- Service – logjika e aplikacionit
- Repository – menaxhimi i të dhënave

---

## Teknologjitë

- ASP.NET Core
- C#
- Repository Pattern
- MSTest për unit testing

---

## Testimi

Projekti përmban unit tests për:
- Shtimin e job-eve
- Filtrimin dhe sortimin
- Aplikimin në job

Të gjitha testet kalojnë me sukses.

---

## Error Handling

- Përdoren try-catch në Service dhe Repository
- Input validohet
- Programi nuk crashon

---

## Si të ekzekutohet

1. Hap projektin në Visual Studio
2. Run `StudentJobPlatform.Web`
3. Aplikacioni hapet në browser

---

## Autori

Verona Ademaj
