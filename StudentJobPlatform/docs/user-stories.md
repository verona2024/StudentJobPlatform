##
User Roles:
*STUDENT*
*EMPLOYER*
*ADMIN*

#User Story 1

User Story:

Si student, dua të krijoj një llogari në platformë, në mënyrë që të mund të përdor sistemin dhe të aplikoj për punë part-time.

Acceptance Criteria:

-Given përdoruesi është në faqen e regjistrimit
-When ai plotëson email dhe fjalëkalim valid
-Then sistemi krijon një llogari të re

-Given studenti ka një llogari ekzistuese
-When ai fut kredencialet e sakta
-Then sistemi e kyç atë në platformë

Priority: *Must Have

--------------

#User Story 2

User Story:

Si student, dua të plotësoj profilin tim me drejtimin e studimeve, aftësitë dhe lokacionin, në mënyrë që sistemi të më rekomandojë punë që lidhen me fushën time.

Acceptance Criteria:

-Given studenti është i kyçur në profilin e tij
-When ai shton drejtimin e studimeve dhe aftësitë
-Then sistemi ruan informacionin në profil

-Given studenti ka plotësuar profilin
-When sistemi shfaq ofertat e rekomanduara
-Then ofertat lidhen me drejtimin e tij të studimeve

Priority: *Must Have

----------------------

#User Story 3

User Story:

Si student, dua të vendos orarin kur jam i lirë për punë, në mënyrë që të gjej punë që nuk përplasen me orarin tim të studimeve.

Acceptance Criteria:

-Given studenti është në profilin e tij
-When ai vendos ditët dhe orët kur është i lirë
-Then sistemi ruan disponueshmërinë

-Given studenti ka vendosur orarin e lirë
-When sistemi shfaq ofertat e rekomanduara
-Then prioritet kanë ofertat që përputhen me atë orar

Priority: *Must Have

-----------------------

#User Story 4

User Story:

Si student, dua të kërkoj dhe filtroj ofertat e punës sipas lokacionit, orarit të punës dhe pagesës, në mënyrë që të gjej punë që më përshtaten.

Acceptance Criteria:

-Given studenti është në faqen e ofertave
-When ai përdor filtrat për lokacion, orar ose pagesë
-Then sistemi shfaq ofertat që përputhen me filtrin

-Given studenti përdor kërkim me fjalë kyçe
-When sistemi përpunon kërkimin
-Then shfaqen ofertat relevante

Priority: *Must Have

--------------------

#User Story 5

User Story:

Si student, dua të aplikoj në një ofertë pune, në mënyrë që të kem mundësi të punoj ose të bëj praktikë në atë kompani.

Acceptance Criteria:

-Given studenti është i kyçur
-When ai klikon butonin "Apply" në një ofertë
-Then aplikimi regjistrohet në sistem

-Given studenti nuk është i kyçur
-When ai klikon "Apply"
-Then sistemi kërkon që ai të kyçet

Priority: *Must Have

--------------------

#User Story 6

User Story:

Si punëdhënës, dua të publikoj një ofertë pune duke specifikuar përshkrimin e punës, orarin e punës, lokacionin dhe pagesën, në mënyrë që studentët të kenë informacion të plotë për ofertën.

Acceptance Criteria:

-Given punëdhënësi është i kyçur në sistem
-When ai plotëson të dhënat e ofertës (titulli, përshkrimi, pagesa, lokacioni dhe orari)
-Then sistemi publikon ofertën në platformë

-Given oferta është publikuar
-When studentët shikojnë listën e ofertave
-Then oferta shfaqet me të gjitha informacionet e saj

Priority: *Must Have

-------------------------

#User Story 7

User Story:

Si punëdhënës, dua të shoh aplikimet e studentëve për ofertën time, në mënyrë që të zgjedh kandidatin më të përshtatshëm.

Acceptance Criteria:

-Given ekzistojnë aplikime për ofertën
-When punëdhënësi hap ofertën
-Then sistemi shfaq listën e aplikimeve

-Given punëdhënësi ndryshon statusin e aplikimit
-When ai zgjedh "Accepted" ose "Rejected"
-Then sistemi ruan statusin e ri

Priority: *Should Have

-----------------

#User Story 8

User Story:

Si student, dua të shoh statusin e aplikimeve të mia, në mënyrë që të di nëse aplikimi është pranuar apo refuzuar.

Acceptance Criteria:

-Given studenti ka aplikuar në një ofertë
-When ai hap seksionin "My Applications"
-Then sistemi shfaq statusin e aplikimit

-Given punëdhënësi ndryshon statusin e aplikimit
-When studenti kontrollon aplikimet
-Then statusi i ri shfaqet në sistem

Priority: *Should Have

--------------

#User Story 9

User Story:

Si student, dua të shoh oferta të rekomanduara bazuar në drejtimin tim të studimeve dhe orarin tim të lirë, në mënyrë që të gjej punë që lidhen me fushën time.

Acceptance Criteria:

-Given studenti ka plotësuar drejtimin dhe disponueshmërinë
-When ai hap seksionin "Recommended Jobs"
-Then sistemi shfaq ofertat që përputhen me drejtimin dhe orarin e tij

Priority: *Could Have

-----------

#User Story 10

User Story:

Si administrator, dua të menaxhoj përdoruesit dhe ofertat në platformë, në mënyrë që sistemi të jetë i sigurt dhe pa abuzime.

Acceptance Criteria:

-Given administratori është i kyçur
-When ai hap panelin e administrimit
-Then mund të shohë dhe menaxhojë përdoruesit dhe ofertat

-Given një përdorues shkel rregullat e platformës
-When administratori vendos ta bllokojë
-Then sistemi e çaktivizon atë llogari

Priority: *Won’t Have (this semester).
