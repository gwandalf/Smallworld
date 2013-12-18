#pragma once
#include <vector>
#include <iterator>
#define NBTYPES 5
#define WANTDLLEXP

#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif

using namespace std;

/**
*
* \struct PositUnite
* \brief Associates a position (line, column) to a unite
*
*/
struct PositUnite {
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
	int cases[15][15]; //an integer represents a type of case ("Foret, Eau, Plaine, Montagne, Desert")
	int dim; //dimension of the map
	vector<vector<PositUnite>> positUnite; //vector of all the different armies

public:
	Carte(void);
	Carte(int dim, int army_length);
	~Carte(void);
	
	void generateCases(int nbTypes);
	void placeUnites(int begin, int end, int lig, int col);
	inline int getDim() {return dim;}
	inline int* getCases() {return cases;}
};

EXTERNC DLL Carte* Carte_New_default();
EXTERNC DLL Carte* Carte_New(int dim, int army_length);
EXTERNC DLL void Carte_Delete(Carte * carte);
