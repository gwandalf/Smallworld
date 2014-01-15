#pragma once
#include "Legion.h"
#include "Sommet.h"
#include <vector>
#include <iterator>
#define NBTYPES 5
#define DIMMAX 15
#define WANTDLLEXP

#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

using namespace std;

class VisiteurConnexite;

/**
*
* \class Carte
* \brief Minimalist representation of the C# "Carte"
*
*/
class DLL Carte
{
	Sommet* cases[DIMMAX][DIMMAX]; //an integer represents a type of case ("Foret, Eau, Plaine, Montagne, Desert")
	int dim; //dimension of the map
	vector<Legion> legions; //vector of all the different armies
	vector<int> nbCases; //number of cases of each type that remain to be placed
	vector<Sommet*> nodes; //set of the cases, seen as nodes of a graph (the map)
	int places[2][2]; //used to store the starting position of the players

public:
	static const enum TYPE {DESERT, PLAINE, FORET, MONTAGNE, EAU};

	Carte(void);
	Carte(int dim, int army_length);
	~Carte(void);
	
	void generateCases(int nbTypes);
	bool isolatedRegion();
	int choose(int nb);
	void addNode(int x, int y);
	void placeUnites(int x, int y, int num);
	int getDim();
	inline vector<Sommet*>& getNodes() { return nodes; }
	int getPlace(int num, int coord) { return places[num][coord]; }
	int getCases(int x, int y);
};


EXTERNC DLL Carte* Carte_New_default();
EXTERNC DLL Carte* Carte_New(int dim, int army_length);
EXTERNC DLL void Carte_Delete(Carte * carte);

