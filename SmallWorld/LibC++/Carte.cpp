#pragma once
#include <cstdlib>
#include <ctime>
#include <queue>
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
	srand(time(0));
	nbCases = vector<int>(NBTYPES);
	nodes = vector<Sommet*>();
	for(int i = 0 ; i < NBTYPES ; i++)
		nbCases[i] = (dim*dim) / NBTYPES;
	if(dim <= DIMMAX)
		this->dim = dim;
	else
		this->dim = DIMMAX;
	generateCases(NBTYPES);
	positUnite = vector<vector<PositUnite>>();
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
* TODO : améliorer l'algorithme pour avoir au moins une fois chaque type de case
*
*/
void Carte::generateCases(int nbTypes)
{
	for(int i = 0 ; i < dim ; i++)
	{
		for(int j = 0 ; j < dim ; j++)
		{
			cases[i][j] = new Sommet(0);
			addNode(i, j);
		}
	}
	for(int i = 0 ; i < dim ; i++)
	{
		for(int j = 0 ; j < dim ; j++)
		{
			cases[i][j]->setTerrain(choose(nbTypes));
			if(cases[i][j]->getTerrain() == EAU)
			{
				unlinkNode(i, j);
				if(((j == dim - 1 && i > 0) ||		//on the right side, ...
					(i == dim - 1) ||				//on the bottom side, ...
					(j == 0 && i > 0)))			//or on the left side, we must verify if ther is not isolated island
				{
					if(isolatedRegion())
						cases[i][j]->setTerrain(choose(nbTypes - 1)); // if the placement of the 'sea' case creates an island, we choose another type
				}
			}
		}
	}
}

//TODO : completer
bool Carte::isolatedRegion()
{
	queue<Sommet*> f;
	nodes[0]->setFlag(true);
	f.push(nodes[0]);
	while(!f.empty())
	{
		Sommet* x = f.front();
		f.pop();
		x->setVisite(true);
		vector<Sommet*>::iterator deb = x->getAdjacents().begin();
		vector<Sommet*>::iterator fin = x->getAdjacents().end();
		vector<Sommet*>::iterator it;
		for(it = deb ; it != fin ; it++)
		{
          Sommet* z = (*it);
          if(!z->getFlag())
		  {
              z->setFlag(true);
              f.push(z);
		  }
		}
	}
	bool res = false;
	vector<Sommet*>::iterator deb = nodes.begin();
	vector<Sommet*>::iterator fin = nodes.end();
	vector<Sommet*>::iterator it;
	for(it = deb ; it != fin && !res ; it++)
	{
		if(!(*it)->getVisite())
			res = true;
		(*it)->setFlag(false);
		(*it)->setVisite(false);
	}
	return res;
}

int Carte::choose(int nb)
{
	bool famine = true;
	for(int i = 0 ; i < NBTYPES && famine ; i++)
	{
		if(nbCases[i] != 0)
			famine = false;
	}
	int res = rand() % nb;
	if(famine)
		return res;
	while(nbCases[res] == 0)
		res = rand() % nb;
	nbCases[res]--;
	return res;
}

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

void Carte::unlinkNode(int x, int y)
{
	vector<Sommet*>::iterator deb = cases[x][y]->getAdjacents().begin();
	vector<Sommet*>::iterator fin = cases[x][y]->getAdjacents().end();
	vector<Sommet*>::iterator it;
	for(it = deb ; it != fin ; it++)
	{
		vector<Sommet*>::iterator debit = cases[x][y]->getAdjacents().begin();
		vector<Sommet*>::iterator finit = cases[x][y]->getAdjacents().end();
		vector<Sommet*>::iterator itit;
		for(itit = debit ; itit != finit ; itit++)
		{
			if(*itit == cases[x][y])
			{
				(*it)->getAdjacents().erase(itit);
				break;
			}
		}
	}
	vector<Sommet*>::iterator debn = nodes.begin();
	vector<Sommet*>::iterator finn = nodes.end();
	vector<Sommet*>::iterator itn;
	for(itn = debn ; itn != finn ; itn++)
	{
		if(*itn == cases[x][y])
		{
			nodes.erase(itn);
			break;
		}
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
			if(i)
			{
				switch(num)
				{
				case 0:
					x1--;
					break;
				case 1:
					x1++;
					break;
				}
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
		suivant = (x > -1 && x < dim && y > -1 && y < dim && !i);
		i = !i;
	}
	if(trouve)
	{
		places[num][0] = x;
		places[num][1] = y;
	}
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

// TODO!
//trouver les bons mouvements
// doit savoir quels sont les terrains environnants
// combien il y a d'ennemis à côté et leur caractéristiques
// suggère 3 emplacements au maximum
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


int* Carte::getMoves(int line, int column, int size) {
	// on doit connaitre la position de l'unité séléctionnée (line,column)
	// En fonction de cela, on garde les cases accessibles physiquement accessibles ( bords de la map) (taille de la carte)
	// on enlève en fonction de l'unité, les cases inaccessibles (getCases()...)
	// Si il y a plus de 3 solutions, on sélectionne les meilleures en fonction des ennemis présents

	// Au max 3 coordonnées seront renvoyées sous la forme d'un tableau [][]

	int pos = line * size + column;

	int x = pos / size;
	int y = pos%size;

	//(i*taille + j);
			
	int i = 0;
	// 9 emplacements (pour simplifier), mais seulement 4 possibles
	int * cases = new int[4];
	
	// l'unité est n'est pas tout en haut de la carte

	if (pos > size){
		cases[i++] = pos - size;
		//OK quand unite en bas, pas ok quand unite en haut
	}
	/*
	if (line == 0){
		// pas de déplacement vers le haut
		cases[0] = cases[1] = cases[2] = -1;
	}
	*/
	// l'unité n'est pas tout en bas de la carte
	if (pos <= size*(size-1)){
		cases[i++] = pos + size;
		//OK quand unite en haut, pas ok quand unite en bas
	}
	/*
	if (line == dim){
		//pas de déplacement vers le bas
		cases[dim] = cases[dim + 1] = cases[dim + 2] = -1;
	}
	*/
	// l'unité n'est pas à gauche de la carte
	/*
	if ((pos % size) == 1){
		cases[i++] = pos - 1;
	}
	*/
	/*
	if (column == 0){
		// pas de déplacement a gauche
		cases[0] = cases[1] = cases[2] = -1;
	}
	*/
	// l'unité n'est pas à droite de la carte
	/*
	if ((pos % (size-1)) != 0){
		cases[i++] = pos + 1;
	}
	*/
	/*
	if (column == dim){
		// pas de déplacement à droite
		cases[dim] = cases[1 + dim] = cases[2 + dim] = -1;
	}
	*/
	/*
	cases[0] = 200;
	cases[1] = 201;
	cases[2] = 202;
	*/
	return cases;
	
}

//vérifier si il y a de l'eau a coté

//trouver le nombre d'unités à une certaine position

//calculer le nombre de points


EXTERNC DLL Carte* Carte_New_default(){return new Carte();}
EXTERNC DLL Carte* Carte_New(int dim, int army_length){return new Carte(dim, army_length);}
EXTERNC DLL void Carte_Delete(Carte * carte){delete carte;}
