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
		void placeUnites(int begin, int end, int lig, int col);

	private:
		Carte* myCarte;

	protected:
		!CarteWrapper();
	};
}
