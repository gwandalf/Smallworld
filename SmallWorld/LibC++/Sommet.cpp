#include "Sommet.h"


Sommet::Sommet(int terrain):_terrain(terrain)
{
	_adjacents = vector<Sommet*>();
	_flag = false;
	_visite = false;
}


Sommet::~Sommet(void)
{
}
