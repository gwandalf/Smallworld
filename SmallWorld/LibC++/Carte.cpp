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
* \fn Carte::Carte(int dim)
* \brief constructor by dimension
*
* \param[in] dim : number of lines and column
* 
*/
Carte::Carte(int dim)
{
	this->dim = dim;
	generateCases(NBTYPES);
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
* \fn Carte::generateCases(int nbTypes)
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
* \fn Carte::placeUnites()
* \brief algorithm placing the unites on the map
*
*/
void Carte::placeUnites(int armyId, vector<int> army, int lig, int col){
	vector<int>::iterator deb = army.begin();
	vector<int>::iterator fin = army.end();
	vector<int>::iterator iter;
	for(iter = deb ; iter != fin ; iter++)
		//TODO
}
