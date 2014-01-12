#pragma once
#include "Legion.h"
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

struct PositUnite
{
	int lig;
	int col;
	int unite;
};

/**
*
* \class Carte
* \brief Minimalist representation of the C# "Carte"
*
*/
class DLL Carte
{
	int cases[DIMMAX][DIMMAX]; //an integer represents a type of case ("Foret, Eau, Plaine, Montagne, Desert")
	int dim; //dimension of the map
	vector<Legion> legions; //vector of all the different armies
	vector<int> nbCases;
	vector<vector<PositUnite>> positUnite;

public:
	static const enum {DESERT, PLAINE, FORET, MONTAGNE, EAU};

	Carte(void);
	Carte(int dim, int army_length);
	~Carte(void);
	
	void generateCases(int nbTypes);
	bool isolatedRegion();
	int choose(int nb);
	void placeUnites(int begin, int end, int lig, int col);
	int getDim();
	int getCases(int x, int y);
	int* getMoves(int ligne, int colonne, int size);
};


EXTERNC DLL Carte* Carte_New_default();
EXTERNC DLL Carte* Carte_New(int dim, int army_length);
EXTERNC DLL void Carte_Delete(Carte * carte);

