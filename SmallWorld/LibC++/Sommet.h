#pragma once
#include <vector>
using namespace std;
class VisiteurConnexite;
class Sommet
{
	vector<Sommet*> _adjacents; //list of adajcents cases
	int _terrain; //type (DESERT, FORET, PLAINE, MONTAGNE, EAU)
	bool _flag; //used to mark as visited
public:
	Sommet(int terrain = 0);
	~Sommet(void);
	inline vector<Sommet*>& getAdjacents() { return _adjacents; }
	inline int getTerrain() { return _terrain; }
	inline void setTerrain(int terrain) { _terrain = terrain; }
	inline bool getFlag() { return _flag; }
	inline void setFlag(bool flag) { _flag = flag; }
	void accept(VisiteurConnexite* vis);
};

