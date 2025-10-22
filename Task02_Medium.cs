using System; 
using System.Collections.Generic;

class GFG { 
   public static List<int> findPeakGrid(int[][] mat) { 
      int n = mat.Length; 
      int m = mat[0].Length;

      for (int i = 0; i < n; ++i) { 
          for (int j = 0; j < m; ++j) {
              int curr = mat[i][j];
              bool isPeak = true; 
     
              if (i > 0 && mat[i - 1][j] > curr) 
                  isPeak = false;
     
              if (i + 1 < n && mat[i + 1][j] > curr)
                  isPeak = false;
  
              if (j > 0 && mat[i][j - 1] > curr) 
                  isPeak = false; 
 
              if (j + 1 < m && mat[i][j + 1] > curr) 
                  isPeak = false;
 
              if (isPeak) { 
                  return new List<int> { i, j };
              }
      }
} 
return new List<int> { -1, -1 };
} 

public static void Main() {
    int[][] mat = new int[][] { 
        new int[] {10, 20, 15},
        new int[] {21, 30, 14},
        new int[] {7, 16, 32},
    };
    List<int> peak = findPeakGrid(mat);
    Console.WriteLine(peak[0] + " " + peak[1]);
  } 
}
