#pragma once
#include <vector>
#include <iterator>
#define NBTYPES 5
#define DIMMAX 15
#define WANTDLLEXP

#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

using namespace std;

/**
*
* \struct PositUnite
* \brief Associates a position (line, column) to a unite
*
*/
struct PositUnite {
	int lig;
	int col;
	int unite;
};

/**
*
* \class Carte
* \brief Minimalist representation of the C# "Carte"
*
*/
class DLL Carte
{
	int cases[DIMMAX][DIMMAX]; //an integer represents a type of case ("Foret, Eau, Plaine, Montagne, Desert")
	int dim; //dimension of the map
	vector<vector<PositUnite>> positUnite; //vector of all the different armies


public:
	Carte(void);
	Carte(int dim, int army_length);
	~Carte(void);
	
	void generateCases(int nbTypes);
	void placeUnites(int begin, int end, int lig, int col);
	int getDim();
	int getCases(int x, int y);
	int* getMoves(int ligne, int colonne);
};

/*

//A mettre dans une classe Combat

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
		// Mise à jour des caracteristiques
		calculeCarac();

		// Calcul de la probabilite que l'attaquant perde une vie
		float proba = 50 * (2 - (att_attaquant / def_defenseur));
		srand((unsigned int) time(NULL));
		int resultat = rand() % 100;
		(resultat<proba) ? pdv_attaquant-- : pdv_defenseur--;
	}
};

*/

EXTERNC DLL Carte* Carte_New_default();
EXTERNC DLL Carte* Carte_New(int dim, int army_length);
EXTERNC DLL void Carte_Delete(Carte * carte);

