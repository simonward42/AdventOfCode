namespace AdventOfCode {
	public static class Day1 {

		/// <summary>
		/// Find the two numbers in Data that sum to 2020, and return their product.
		/// </summary>
		/// <returns></returns>
		public static int SolvePart1() {

			int currentIndex = 0;
			int solutionIndex;
			int partnerIndex;

			do {
				solutionIndex = currentIndex;
				partnerIndex = CheckGivenEntryForPartnerSummingTo2020(currentIndex);
			}
			while (partnerIndex == -1 && ++currentIndex < Data.Length);

			if (Data[solutionIndex] + Data[partnerIndex] != 2020) {
				throw new System.Exception("Woah! Something's gone wrong!");
			}

			return Data[solutionIndex] * Data[partnerIndex];
		}

		/// <summary>
		/// Find the three numbers in Data that sum to 2020, and return their product.
		/// </summary>
		/// <returns></returns>
		public static int SolvePart2() {

			int entry1 = 0;
			int entry2 = 0;
			int entry3 = 0;

			int sum = 0;

			for (int index1 = 0; index1 < Data.Length; index1++) {

				if (sum == 2020) {
					break;
				}

				for (int index2 = index1 + 1; index2 < Data.Length; index2++) {

					if (sum == 2020) {
						break;
					}

					for (int index3 = index2 + 1; index3 < Data.Length; index3++) {

						entry1 = Data[index1];
						entry2 = Data[index2];
						entry3 = Data[index3];

						sum = entry1 + entry2 + entry3;

						if (sum == 2020) {
							break;
						}
					}
				}
			}

			return entry1 * entry2 * entry3;
		}

		/// <summary>
		/// CheckGivenEntryForPartnerSummingTo2020
		/// </summary>
		/// <returns>Index of the partner summing to 2020 if found, otherwise -1</returns>
		public static int CheckGivenEntryForPartnerSummingTo2020(int entryIndex) {
			var result = -1;
			var sum = 0;
			var partnerIndex = -1;

			while (sum != 2020 && ++partnerIndex < Data.Length) {
				if (partnerIndex == entryIndex) {
					continue;
				}

				if (Data[entryIndex] + Data[partnerIndex] == 2020) {
					result = partnerIndex;
				}
			}

			return result;
		}


		public static int[] Data = {1472,
			1757,
			1404,
			1663,
			1365,
			1974,
			1649,
			1489,
			1795,
			1821,
			1858,
			1941,
			1943,
			1634,
			1485,
			1838,
			817 ,
			1815,
			1442,
			639 ,
			1182,
			1632,
			1587,
			1918,
			1040,
			1441,
			1784,
			1725,
			1951,
			1285,
			285 ,
			1224,
			1755,
			1748,
			1488,
			1374,
			1946,
			1771,
			1809,
			1929,
			1621,
			1462,
			2001,
			1588,
			1888,
			1959,
			1787,
			1690,
			1363,
			1567,
			1853,
			1990,
			1819,
			1904,
			1458,
			1882,
			1348,
			1957,
			1454,
			1557,
			1471,
			332 ,
			1805,
			1826,
			1745,
			1154,
			1423,
			1852,
			1751,
			1194,
			1430,
			1849,
			1962,
			1577,
			1470,
			1509,
			1673,
			1883,
			1479,
			1487,
			2007,
			1555,
			1504,
			1570,
			2004,
			978 ,
			1681,
			1631,
			1791,
			1267,
			1245,
			1383,
			1482,
			1355,
			1792,
			1806,
			1376,
			1199,
			1391,
			1759,
			1474,
			1268,
			1942,
			1936,
			1766,
			1233,
			1876,
			1674,
			1761,
			1542,
			1468,
			1543,
			1986,
			2005,
			1689,
			1606,
			1865,
			1783,
			1807,
			1779,
			1860,
			1408,
			1505,
			1435,
			1205,
			1952,
			1201,
			1714,
			1743,
			1872,
			1897,
			1978,
			1683,
			1846,
			858 ,
			1528,
			1629,
			1510,
			1446,
			1869,
			1347,
			685 ,
			1478,
			1387,
			687 ,
			1964,
			1968,
			1429,
			1460,
			1777,
			1417,
			1768,
			1672,
			1767,
			1400,
			1914,
			1715,
			1425,
			1700,
			1756,
			1835,
			1926,
			1889,
			1568,
			1393,
			1960,
			1540,
			1810,
			1401,
			1685,
			830 ,
			1789,
			1652,
			1899,
			796 ,
			1483,
			1261,
			1398,
			1727,
			1566,
			1812,
			1937,
			1993,
			1286,
			1992,
			1611,
			1825,
			1868,
			1870,
			1746,
			1361,
			1418,
			1820,
			1598,
			1911,
			1428,
			1734,
			1833,
			1436,
			1560};

	}
}
