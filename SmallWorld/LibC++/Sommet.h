#pragma once
#include <vector>
using namespace std;
class Sommet
{
	vector<Sommet*> _adjacents;
	int _terrain;
	bool _flag;
	bool _visite;
public:
	Sommet(int terrain = 0);
	~Sommet(void);
	inline vector<Sommet*>& getAdjacents() { return _adjacents; }
	inline int getTerrain() { return _terrain; }
	inline void setTerrain(int terrain) { _terrain = terrain; }
	inline bool getFlag() { return _flag; }
	inline void setFlag(bool flag) { _flag = flag; }
	inline bool getVisite() { return _visite; }
	inline void setVisite(bool visite) { _visite = visite; }
};

