Functionaliteit: Korting toepassen bij meerdere produkten
Als klant wil ik 5% korting hebben op de aankoop als ik 10 of meer produkten afneem.

Achtergrond: 
    Gegeven de volgende klanten
    | Klant identificatie |
    | KL123               | 
    En de volgende produkten
    | Produkt identificatie | Prijs |
    | Appel                 | 0.58  |
    | Banaan                | 0.98  |

Scenario: Bij afname van minder dan 10 produkten wordt er geen korting gegeven
	Gegeven klant 'KL123'
    Als ik '9' aantal van het produkt 'Appel' bestel
    Dan wordt het totaalbedrag '5.22'

Scenario: Bij afname van meer dan 10 produkten wordt er 5 procent korting gegeven
	Gegeven klant 'KL123'
    Als ik '10' aantal van het produkt 'Appel' bestel
    Dan wordt het totaalbedrag '5.51'