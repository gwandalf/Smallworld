#include "VisiteurConnexite.h"


VisiteurConnexite::VisiteurConnexite(void)
{
}


VisiteurConnexite::~VisiteurConnexite(void)
{
}

void VisiteurConnexite::visitCarte(Carte* carte)
{
	carte->accept(this);
}

void VisiteurConnexite::visitNode(Sommet* node)
{

}

bool VisiteurConnexite::isolatedRegion(Carte carte)
{
	queue<Sommet*> f;
	carte.getNodes()[0]->setFlag(true);
	f.push(carte.getNodes()[0]);
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
	vector<Sommet*>::iterator deb = carte.getNodes().begin();
	vector<Sommet*>::iterator fin = carte.getNodes().end();
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
