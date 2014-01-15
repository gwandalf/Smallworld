#include "VisiteurConnexite.h"


VisiteurConnexite::VisiteurConnexite(void)
{
}


VisiteurConnexite::~VisiteurConnexite(void)
{
}

void VisiteurConnexite::visitCarte(Carte* carte)
{
	int i = 0;
	while(carte->getNodes()[i]->getTerrain() == Carte::EAU)
		i++;
	carte->getNodes()[i]->accept(this);
}

void VisiteurConnexite::visitNode(Sommet* node)
{
	//mark this node as visited
	node->setFlag(true);

	//visit of its neighbours
	vector<Sommet*>::iterator it;
	vector<Sommet*>& adj = node->getAdjacents();
	for(it = adj.begin() ; it != adj.end() ; it++)
	{
		Sommet* z = (*it);
        if(!z->getFlag())
		{
            z->setFlag(true);
            z->accept(this);
		}
	}
}

bool VisiteurConnexite::isolatedRegion(Carte* carte)
{
	bool res = false;
	visitCarte(carte);
	vector<Sommet*>::iterator deb = carte->getNodes().begin();
	vector<Sommet*>::iterator fin = carte->getNodes().end();
	vector<Sommet*>::iterator it;
	for(it = deb ; it != fin && !res ; it++)
	{
		if(!(*it)->getFlag() && (*it)->getTerrain() != Carte::EAU)
			res = true;
		(*it)->setFlag(false);
	}
	return res;
}
