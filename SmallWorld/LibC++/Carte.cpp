#pragma once
#include <cstdlib>
#include <ctime>
#include <queue>
#include "Carte.h"
#include "VisiteurConnexite.h"

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
	//initializations
	srand(time(0));
	nbCases = vector<int>(NBTYPES);
	nodes = vector<Sommet*>();

	//each case must be put (dim*dim) / NBTYPES times, for the map to be well balanced
	for(int i = 0 ; i < NBTYPES ; i++)
		nbCases[i] = (dim*dim) / NBTYPES;
	if(dim <= DIMMAX)
		this->dim = dim;
	else
		this->dim = DIMMAX;

	//generation of the map
	generateCases(NBTYPES);

	//players placement
	placeUnites(0, 0, 0);
	placeUnites(dim-1, dim-1, 1);
}

/**
* \fn Carte::~Carte(void)
* \brief destructor
* 
*/
Carte::~Carte(void)
{
	for(int i = 0 ; i < dim ; i++)
	{
		for(int j = 0 ; j < dim ; j++)
		{
			delete cases[i][j];
		}
	}
}

/**
* \fn void Carte::generateCases(int nbTypes)
* \brief algorithm associating types to cases
*
* \param[in] nbTypes : number of types of the cases
* 
*
*/
void Carte::generateCases(int nbTypes)
{
	//creation of all the cases, initialized as DESERT
	for(int i = 0 ; i < dim ; i++)
	{
		for(int j = 0 ; j < dim ; j++)
		{
			cases[i][j] = new Sommet(0);
			addNode(i, j);
		}
	}

	//choose of the type
	for(int i = 0 ; i < dim ; i++)
	{
		for(int j = 0 ; j < dim ; j++)
		{
			
			cases[i][j]->setTerrain(choose(nbTypes));

			/*
			If a placed case is of type EAU, we verifiy if it doesn't create an unreachable case.
			If it is the case, we simply choose another type of case
			*/
			if(cases[i][j]->getTerrain() == EAU)
			{
				VisiteurConnexite vis;
				if(vis.isolatedRegion(this))
					cases[i][j]->setTerrain(choose(nbTypes-1));
			}
		}
	}
}

//choose a random number between 0 and nb (not included)
//the number will be associated to its corresponding type of case
int Carte::choose(int nb)
{
	//find out if it remains available types of cases
	bool famine = true;
	for(int i = 0 ; i < NBTYPES && famine ; i++)
	{
		if(nbCases[i] != 0)
			famine = false;
	}
	int res = rand() % nb;

	//if there are not, we simply choose the number and that's all...
	if(famine)
		return res;

	//else, we look for a type of case which is available
	while(nbCases[res] == 0)
		res = rand() % nb;
	nbCases[res]--;
	return res;
}

//makes links between the case located at (x, y) and the adjacents cases
void Carte::addNode(int x, int y)
{
	if(cases[x][y] != NULL)
	{
		nodes.push_back(cases[x][y]);
		if(x-1 >= 0)
		{
			cases[x][y]->getAdjacents().push_back(cases[x-1][y]);
			cases[x-1][y]->getAdjacents().push_back(cases[x][y]);
		}
		if(y-1 >= 0)
		{
			cases[x][y]->getAdjacents().push_back(cases[x][y-1]);
			cases[x][y-1]->getAdjacents().push_back(cases[x][y]);
		}
	}
}

/**
* \fn void Carte::placeUnites(int x, int y, int num)
* \brief algorithm placing the unites on the map
* 
* By default, the algorithm places the player at the given position.
* But if the case is of type EAU, it finds out the nearest available position.
*
* \param[in] x : line suggested
* \param[in] y : column suggested
* \param[in] num : id of the player
* 
*/
void Carte::placeUnites(int x, int y, int num)
{
	int sx = x;
	int sy = y;
	int x1 = x;
	int y1 = y;
	int x2 = x;
	int y2 = y;
	bool i = false;
	bool suivant = true;
	bool trouve = false;
	while(suivant && !trouve)
	{
		if(cases[x][y]->getTerrain() != EAU)
			trouve = true;
		else
		{
			//the algorithm alternates between a research on the first position's line and the first position's column
			//this "complication" is due to the fact that we choose the nearest position
			if(i)
			{
				switch(num)
				{
				case 0:     //case in which the player is first placed at the top-right corner of the map
					x1--;
					break;
				case 1:		//case in which the player is first placed at the bottom-left corner of the map
					x1++;
					break;
				}
				//let's try with this position...
				x = x1;
				y = y1;
			}

			else
			{
				switch(num)
				{
				case 0:
					y2--;
					break;
				case 1:
					y2++;
					break;
				}
				x = x2;
				y = y2;
			}
		}
		//tests if the border of the map is reached.
		suivant = (x > -1 && x < dim && y > -1 && y < dim && !i);
		i = !i;
	}
	if(trouve)
	{
		places[num][0] = x;
		places[num][1] = y;
	}
	//In case of reached border, we look for a bit farer position...
	else if(num == 0)
		placeUnites(sx+1, sy+1, num);
	else
		placeUnites(sx-1, sy-1, num);

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
		return cases[x][y]->getTerrain();
	else
		return -1;
}


EXTERNC DLL Carte* Carte_New_default(){return new Carte();}
EXTERNC DLL Carte* Carte_New(int dim, int army_length){return new Carte(dim, army_length);}
EXTERNC DLL void Carte_Delete(Carte * carte){delete carte;}
