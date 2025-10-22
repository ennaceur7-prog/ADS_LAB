using System;
using System.Collections.Generic;

class GFG { 

   static int getMaxArea(int[] heights) { 
       int n = heights.Length; 
       Stack<int> s = new Stack<int>();
       int res = 0; 
     
       for (int i = 0; i < n; i++) {

          while (s.Count > 0 && heights[s.Peek()] >=
heights[i]) {
              int tp = s.Pop();
             
              int width = (s.Count == 0) ? i : i - s.Peek() - 
1;

              res = Math.Max(res, heights[tp] * width); 
            }
            s.Push(i);
       }
       while (s.Count > 0) {
          int tp = s.Pop(); 
          int width = (s.Count == 0) ? n : n - s.Peek() - 1;
          res = Math.Max(res, heights[tp] * width);
      }
      return res;
}

static int maxArea(int[,] mat) { 
    int n = mat.GetLength(0), m = mat.GetLength(1);

    int[] heights = new int[m];
    int ans = 0;

    for (int i = 0; i < n; i++) { 
        for (int j = 0; j < m; j++) { 
   
            if (mat[i, j] == 1) heights[j]++;
            else heights[j] = 0;
        }
        ans = Math.Max(ans, getMaxArea(heights));
    }
    return ans;
}

static void Main() {
    int[,] mat = {
        {0,1,1,0},
        {1,1,1,1},
        {1,1,1,1},
        {1,1,0,0},
};

Console.WriteLine(maxArea(mat));
 }
}  
