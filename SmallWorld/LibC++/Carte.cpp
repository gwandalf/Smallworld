#pragma once
#include <cstdlib>
#include "Carte.h"

using namespace std;

/**
* \fn Carte::Carte(void)
* \brief default constructor
* 
*/
_declspec(dllexport) Carte::Carte(void)
{
}

/**
* \fn Carte::Carte(int dim, int army_length)
* \brief constructor by dimension
*
* \param[in] dim : number of lines and columns
* \param[in] army_length : number of unites in the army
* 
*/
_declspec(dllexport) Carte::Carte(int dim, int army_length)
{
	this->dim = dim;
	generateCases(NBTYPES);
	placeUnites(0, army_length, 0, 0);
	placeUnites(army_length, 2*army_length, dim, dim);
}

/**
* \fn Carte::~Carte(void)
* \brief destructor
* 
*/
_declspec(dllexport) Carte::~Carte(void)
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
_declspec(dllexport) void Carte::generateCases(int nbTypes) {
	for(int i = 0 ; i < dim ; i++) {
		for(int j = 0 ; j < dim ; j++)
			cases[i][j] = rand() % nbTypes;
	}
}

/**
* \fn void Carte::placeUnites(int army_length, int lig, int col)
* \brief algorithm placing the unites on the map
* 
* \param[in] army_length : number of unites in the army
* \param[in] lig : line reference
* \param[in] col : column reference
* 
*/
_declspec(dllexport) void Carte::placeUnites(int begin, int end, int lig, int col) {
	positUnite = vector<vector<PositUnite>>();
	positUnite.push_back(vector<PositUnite>());
	for(int i = begin ; i < end ; i++) {
		PositUnite pu;
		pu.col = col;
		pu.lig = lig;
		pu.unite = i;
		positUnite.end()->push_back(pu);
	}
}
/*
extern "C" _declspec(dllexport) Carte* Carte_New_default(){return new Carte();}
extern "C" _declspec(dllexport) Carte* Carte_New(int dim, vector<int> army1, vector<int> army2){return new Carte(dim, army1, army2);}
extern "C" _declspec(dllexport) void Carte_Delete(Carte * carte){delete carte;}
*/