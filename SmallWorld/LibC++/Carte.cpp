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
* \fn Carte::Carte(int dim, int army_length)
* \brief constructor by dimension
*
* \param[in] dim : number of lines and columns
* \param[in] army_length : number of unites in the army
* 
*/
Carte::Carte(int dim, int army_length)
{
	if(dim <= DIMMAX)
		this->dim = dim;
	else
		this->dim = DIMMAX;
	generateCases(NBTYPES);
	positUnite = vector<vector<PositUnite>>();
	placeUnites(0, army_length, 0, 0);
	placeUnites(army_length, 2*army_length, this->dim - 1, this->dim - 1);
}

/**
* \fn Carte::~Carte(void)
* \brief destructor
* 
*/
Carte::~Carte(void)
{
}

/**
* \fn void Carte::generateCases(int nbTypes)
* \brief algorithm associating types to cases
*
* \param[in] nbTypes : number of types of the cases
* 
* TODO : am�liorer l'algorithme pour avoir au moins une fois chaque type de case
*
*/
void Carte::generateCases(int nbTypes) {
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
void Carte::placeUnites(int begin, int end, int lig, int col) {
	positUnite.push_back(vector<PositUnite>());
	for(int i = begin ; i < end ; i++) {
		PositUnite pu;
		pu.col = col;
		pu.lig = lig;
		pu.unite = i;
		positUnite.back().push_back(pu);
	}
}

int Carte::getDim() {return dim;}

/**
* \fn int Carte::getCases(int x, int y)
* \brief access the number located at the specified position
* 
* \param[in] x : column number
* \param[in] y : line number
*
* return : the number located at the specified position or -1 if the parameters are invalid
*/
int Carte::getCases(int x, int y) {
	if(x < DIMMAX && y < DIMMAX)
		return cases[x][y];
	else
		return -1;
}

// TODO!
//trouver les bons mouvements
// doit savoir quels sont les terrains environnants
// combien il y a d'ennemis � c�t� et leur caract�ristiques
// sugg�re 3 emplacements au maximum
/*
	0 : DESERT
	1 : WATER
	2 : FOREST
	3 : MOUNTAIN
	4 : LOWLAND

	0 : VICKING
	1 : NAIN
	2 : GAULOIS
*/


int* Carte::getMoves(int line, int column) {
	// on doit connaitre la position de l'unit� s�l�ctionn�e (line,column)
	// En fonction de cela, on garde les cases accessibles physiquement accessibles ( bords de la map) (taille de la carte)
	// on enl�ve en fonction de l'unit�, les cases inaccessibles (getCases()...)
	// Si il y a plus de 3 solutions, on s�lectionne les meilleures en fonction des ennemis pr�sents

	// Au max 3 coordonn�es seront renvoy�es sous la forme d'un tableau [][]

	// 9 emplacements (pour simplifier), mais seulement 4 possibles
	int * cases = new int[9];
	// l'unit� est tout en haut de la carte
	if (line == 0){
		// pas de d�placement vers le haut
		cases[0] = cases[1] = cases[2] = -1;
	}
	// l'unit� est tout en bas de la carte
	if (line == dim){
		//pas de d�placement vers le bas
		cases[dim] = cases[dim + 1] = cases[dim + 2] = -1;
	}
	// l'unit� est � gauche de la carte
	if (column == 0){
		// pas de d�placement a gauche
		cases[0] = cases[1] = cases[2] = -1;
	}
	// l'unit� est � droite de la carte
	if (column == dim){
		// pas de d�placement � droite
		cases[dim] = cases[1 + dim] = cases[2 + dim] = -1;
	}
	return cases;
}

//v�rifier si il y a de l'eau a cot�

//trouver le nombre d'unit�s � une certaine position

//calculer le nombre de points


EXTERNC DLL Carte* Carte_New_default(){return new Carte();}
EXTERNC DLL Carte* Carte_New(int dim, int army_length){return new Carte(dim, army_length);}
EXTERNC DLL void Carte_Delete(Carte * carte){delete carte;}
