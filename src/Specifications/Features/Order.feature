Functionaliteit: 5% korting toepassen voor een specifieke klant
Als klant wil ik 5% korting hebben op de aankoop als ik 10 of meer produkten afneem.

Scenario: Bij afname van minder dan 10 produkten wordt er geen korting gegeven
	Gegeven '9' afgenomen produkten
    Als ik produkten bestel
    Dan wordt er '0' procent korting gegeven

Scenario: Bij afname van meer dan 10 produkten wordt er 5 procent korting gegeven
	Gegeven '10' afgenomen produkten
    Als ik produkten bestel
    Dan wordt er '5' procent korting gegeven