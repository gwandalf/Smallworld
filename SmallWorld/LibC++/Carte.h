#pragma once
#include <vector>
#include <iterator>
#define NBTYPES 5

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
class Carte
{
	int ** cases; //an integer represents a type of case ("Foret, Eau, Plaine, Montagne, Desert")
	int dim; //dimension of the map
	vector<vector<PositUnite>> positUnite; //vector of all the different armies

public:
	Carte(void);
	Carte(int dim, vector<int> army1, vector<int> army2);
	~Carte(void);

	void generateCases(int nbTypes);
	void placeUnites(vector<int> unites, int lig, int col);
};

extern "C" _declspec(dllexport) Carte* Carte_New();
extern "C" _declspec(dllexport) Carte* Carte_New(int dim, vector<int> army1, vector<int> army2);
extern "C" _declspec(dllexport) void Carte_Delete(Carte * carte);

