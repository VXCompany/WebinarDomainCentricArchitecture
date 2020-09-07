﻿Functionaliteit: Korting toepassen bij meerdere produkten
Als klant wil ik 5% korting hebben op de aankoop als ik 10 of meer produkten afneem.

Achtergrond: 
    Gegeven klant 'KL123'
    En de volgende produkten
    | Produkt identificatie | Prijs |
    | Appel                 | 0.58  |
    | Banaan                | 0.98  |

Scenario: Bij afname van minder dan 10 produkten wordt er geen korting gegeven
	Gegeven '9' afgenomen produkten
    Als ik produkten bestel
    Dan wordt er '0' procent korting gegeven

Scenario: Bij afname van meer dan 10 produkten wordt er 5 procent korting gegeven
	Gegeven '10' afgenomen produkten
    Als ik produkten bestel
    Dan wordt er '5' procent korting gegeven