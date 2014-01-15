#include "Sommet.h"
#include "VisiteurConnexite.h"


Sommet::Sommet(int terrain):_terrain(terrain)
{
	_adjacents = vector<Sommet*>();
	_flag = false;
}


Sommet::~Sommet(void)
{
}

void Sommet::accept(VisiteurConnexite* vis)
{
	if(_terrain != Carte::EAU)
		vis->visitNode(this);
}