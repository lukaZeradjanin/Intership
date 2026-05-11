# HR Platform - Upravljanje kandidatima

REST API za upravljanje kandidatima i njihovim veštinama, razvijen u C# .NET 8.

## Tehnologije
- .NET 8
- Entity Framework Core
- SQL Server
- xUnit

## Pokretanje
1. Kloniraj repozitorijum
2. Pokreni migracije: `dotnet ef database update`
3. Pokreni projekat: `dotnet run`

---

## Najzanimljiviji deo zadatka

Odlučio sam da uvedem service sloj kao posrednika između kontrolera i baze podataka.
Kontroler prima HTTP zahtev i vraća odgovor (200, 404, 400...), servis sadrži poslovnu
logiku kao što su provera duplikata emaila, validacija skill ID-jeva i pretraga,
a DbContext se bavi isključivo pristupom bazi.

Za unit testove koristio sam xUnit i in-memory bazu kako testovi ne bi zavisili od
stvarne baze. Testirao sam AddCandidate — da vraća null kada kandidat sa istim emailom
već postoji (case insensitive), i SearchCandidates — da ispravno pronalazi kandidata
po imenu. Ova dva slučaja su mi bila najbitnija jer su direktno vezana za poslovne
zahteve zadatka — jedinstvenost emaila i pretraga.
