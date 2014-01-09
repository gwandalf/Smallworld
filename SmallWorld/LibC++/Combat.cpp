#include "Combat.h"


Combat::Combat(int pdv_att, int pdv_att_max, int pdv_def, int pdv_def_max, int pts_att, int pts_def)
{
	pdv_attaquant_max = pdv_att_max;
	pdv_attaquant = pdv_att;
	pdv_defenseur_max = pdv_def_max;
	pdv_defenseur = pdv_def;
	points_att_attaquant = pts_att;
	points_def_defenseur = pts_def;
}

Combat::~Combat(){}

void Combat::calculeCarac()
{
	att_attaquant = (pdv_attaquant / pdv_attaquant_max) * points_att_attaquant;
	def_defenseur = (pdv_defenseur / pdv_defenseur_max) * points_def_defenseur;
}



void Combat::combattre()
{
	// Calcul du nombre de combats
	srand((unsigned int) time(NULL));
	int nbTours = rand() % (std::max(pdv_attaquant, pdv_defenseur)) + 3;

	// 
	int i = 0;
	while (i<nbTours && (std::min(pdv_attaquant, pdv_defenseur)>0))
	{
		// Mise � jour des caracteristiques
		calculeCarac();

		// Calcul de la probabilite que l'attaquant perde une vie
		float proba = 50 * (2 - (att_attaquant / def_defenseur));
		srand((unsigned int) time(NULL));
		int resultat = rand() % 100;
		(resultat<proba) ? pdv_attaquant-- : pdv_defenseur--;
	}
};