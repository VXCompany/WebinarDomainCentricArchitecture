Functionaliteit: Korting toepassen bij meerdere producten
Als klant wil ik 5% korting hebben op de aankoop als ik 10 of meer producten afneem.

Achtergrond: 
    Gegeven de volgende klanten
    | Klant identificatie |
    | KL123               | 
    En de volgende producten
    | Product identificatie | Prijs |
    | Appel                 | 0.58  |
    | Banaan                | 0.98  |

Scenario: Bij afname van minder dan 10 producten wordt er geen korting gegeven
	Gegeven klant 'KL123'
    Als ik '9' aantal van het product 'Appel' bestel
    Dan wordt het totaalbedrag '5.22'

Scenario: Bij afname van meer dan 10 producten wordt er 5 procent korting gegeven
	Gegeven klant 'KL123'
    Als ik '10' aantal van het product 'Appel' bestel
    Dan wordt het totaalbedrag '5.51'