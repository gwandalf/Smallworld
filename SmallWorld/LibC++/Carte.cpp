#pragma once
#include <cstdlib>
#include "Carte.h"

using namespace std;

/**
* \fn Carte::Carte(void)
* \brief default constructor
* 
*/
Carte::Carte(void)
{
}

/**
* \fn Carte::Carte(int dim, vector<int> army1, vector<int> army2)
* \brief constructor by dimension
*
* \param[in] dim : number of lines and columns
* 
*/
Carte::Carte(int dim, vector<int> army1, vector<int> army2)
{
	this->dim = dim;
	generateCases(NBTYPES);
	placeUnites(army1, 0, 0);
	placeUnites(army1, dim, dim);
}

/**
* \fn Carte::~Carte(void)
* \brief destructor
* 
*/
Carte::~Carte(void)
{
	for(int i = 0 ; i < dim ; i++) {
		delete cases[i];
	}
	delete cases;
}

/**
* \fn void Carte::generateCases(int nbTypes)
* \brief algorithm associating types to cases
*
* \param[in] nbTypes : number of types of the cases
* 
* TODO : améliorer l'algorithme pour avoir au moins une fois chaque type de case
*
*/
void Carte::generateCases(int nbTypes) {
	for(int i = 0 ; i < dim ; i++) {
		for(int j = 0 ; j < dim ; j++)
			cases[i][j] = rand() % nbTypes;
	}
}

/**
* \fn void Carte::placeUnites(vector<int> army, int lig, int col)
* \brief algorithm placing the unites on the map
*
*/
void Carte::placeUnites(vector<int> army, int lig, int col) {
	vector<int>::iterator deb = army.begin();
	vector<int>::iterator fin = army.end();
	vector<int>::iterator iter;
	positUnite = vector<vector<PositUnite>>();
	positUnite.push_back(vector<PositUnite>());
	for(iter = deb ; iter != fin ; iter++) {
		PositUnite pu;
		pu.col = col;
		pu.lig = lig;
		pu.unite = *iter;
		positUnite.end()->push_back(pu);
	}
}

extern "C" _declspec(dllexport) Carte* Carte_New(){return new Carte();}
extern "C" _declspec(dllexport) Carte* Carte_New(int dim, vector<int> army1, vector<int> army2){return new Carte(dim, army1, army2);}
extern "C" _declspec(dllexport) void Carte_Delete(Carte * carte){delete carte;}
