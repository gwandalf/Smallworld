// Wrapper.h

#pragma once
#include "..\LibC++\Carte.h"
#pragma comment (lib, "LibC++.lib")

using namespace System;

namespace Wrapper {

	/**
	*
	* \class CarteWrapper
	* \brief Minimalist representation of the C# "Carte"
	*
	*/
	public ref class CarteWrapper
	{

	public:
		CarteWrapper(void);
		CarteWrapper(int dim, int army_length);
		~CarteWrapper(void);

		void generateCases(int nbTypes);
		int getPlace(int num, int coord);
		void placeUnites(int begin, int end, int lig);
		int getDim();
		int getCases(int x, int y);

	private:
		Carte* myCarte;

	protected:
		!CarteWrapper();
	};

}