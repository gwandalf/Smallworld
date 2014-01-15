#pragma once
#include "Carte.h"
#include <queue>

/*
 * \class VisiteurConnexite
 * 
 * visit a graph and determine if it is connex
 *
 **/
class VisiteurConnexite
{
public:
	VisiteurConnexite(void);
	~VisiteurConnexite(void);

	void visitCarte(Carte* carte);
	void visitNode(Sommet* node);
	bool isolatedRegion(Carte carte);
};

