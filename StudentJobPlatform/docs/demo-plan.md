# Demo Plan — StudentJobPlatform

## 1. Titulli i projektit
StudentJobPlatform — Platformë për lidhjen e studentëve me punëdhënësit

---

## 2. Problemi që zgjidh

Studentët shpesh kanë vështirësi të gjejnë punë ose praktika relevante për profilin e tyre, ndërsa punëdhënësit kërkojnë kandidatë të rinj.

Ky projekt synon të zgjidhë këtë problem duke ofruar një platformë ku:
- studentët mund të kërkojnë dhe aplikojnë për punë
- punëdhënësit mund të publikojnë dhe menaxhojnë oferta

---

## 3. Përdoruesit kryesorë

- **Studentët** → kërkojnë dhe aplikojnë për job-e  
- **Employer-at** → publikojnë dhe menaxhojnë job-e  
- **Admin** → monitoron sistemin  

---

## 4. Flow-i që do ta demonstroj

Flow-i kryesor që do të demonstroj është:

👉 Shfaqja e job-eve → aplikimi në job → validimi → rezultati

Ky flow u zgjodh sepse:
- është funksionaliteti kryesor i sistemit
- përfshin logjikë reale (validation + error handling)
- tregon ndërveprimin e plotë user → system

---

## 5. Një problem real që e kam zgjidhur

### Problemi
Përdoruesi mund të aplikonte disa herë në të njëjtin job.

### Ku ishte problemi
Në versionin fillestar, nuk kishte kontroll për aplikime të dyfishta në ApplicationService.

### Zgjidhja
U implementua kontroll në metodën `ApplyToJob` që verifikon nëse përdoruesi ka aplikuar më parë duke përdorur logjikë në service layer.

### Rezultati
- Parandalohen aplikimet e dyfishta  
- Sistemi jep feedback të qartë për përdoruesin  
- Rritet reliability i aplikacionit  

---

## 6. Çka mbetet ende e dobët

- Nuk përdoret databazë reale (aktualisht JSON/CSV)
- Validimi mund të bëhet më i avancuar
- UI mund të rafinohet më tej për experience më të mirë
- Mund të shtohen integration tests për flow-t kryesore

---

## 7. Struktura e prezantimit (5–7 min)

### 1. Hyrja (30 sek)
- Çfarë është projekti
- Çfarë problemi zgjidh

### 2. Demo live (2–3 min)
- Shfaq job-et
- Apliko në një job
- Provo aplikim të dytë (error case)

### 3. Shpjegimi teknik (1–2 min)
- Arkitektura (UI → Service → Repository)
- ApplicationService dhe ValidationHelper

### 4. Problemi + zgjidhja (1 min)
- Aplikimet e dyfishta
- Si u zgjidhën

### 5. Përfundimi (30 sek)
- Çka funksionon mirë
- Çka mund të përmirësohet

---

## 8. Demo Readiness / Plan B

Në rast se diçka nuk funksionon gjatë demo-s:

- Do përdor screenshot si backup
- Do referohem te unit tests për të treguar funksionalitetin
- Do shpjegoj logjikën e implementimit

---

## 9. Pika kryesore që dua të theksoj

- Sistemi nuk është vetëm UI — ka logjikë reale në backend
- Validimi dhe error handling janë të implementuara
- Projekti është i strukturuar në shtresa (clean architecture)