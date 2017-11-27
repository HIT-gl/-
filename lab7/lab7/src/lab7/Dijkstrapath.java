/**
 * 
 */
package lab7;

import java.io.IOException;

/**
 * @author Administrator
 *
 */
public class Dijkstrapath {
    public String Dijkstra(garph G,String word1) throws IOException
    {  
         //  System.out.print(reallen);
           int n , degree, degree2;  
           int minweight = G.MAX_WEIGHT;  
           int minUn = 0;
           for (n = 0;n < G.words.length ; n++)
               if (G.words[n] == null)
               {
                    break;
               }
        //       else
        //           System.out.println(words[n]);
                  
           int [][] edge2 = new int[n][n];
           int[] minmatrix = new int[n];// ��ŵ�ǰ��ʼ��0�������������ľ��룻  
           boolean[] isS = new boolean[n];// �жϸ����Ƿ񱻷��ʹ�  
           String[] route = new String[n];// ÿ���ַ�������ʾ��Ӧ��ֹ������̾����·����
           int word1_index = G.match(G.words,word1);
    //     System.out.print("word1_index  ");
    //     System.out.println(n);
           String sentence = "";
        //   Stringbuilder
           if (word1_index == -1)
               return "ERROR";
           for (int i = 0 ; i < n ;i++) 
           {
                for (int j = 0 ; j < n ; j++)
                {
                    edge2[i][j]=G.edge[i][j];
                    if((i!=j)&&(edge2[i][j]==0))
                        edge2[i][j] = G.MAX_WEIGHT;
                }       
                
            }
           for (int i = 0; i < n; i++) 
           if(i!=word1_index){// ��ʼ��  
           //    System.out.print(word1_index);
               minmatrix[i] = edge2[word1_index][i];  
               isS[i] = false;  
               route[i] = G.words[word1_index] +"->" + G.words[i];    
           }  
           degree2 = word1_index;
           for (int i = 0; i < n; i++) 
           {             
           // ѡ�� ��ǰ ����� ��ͨ�ģ���ֵ��С�Ķ��㣻  
               degree = word1_index;
               for (int k = 0; k < n; k++) 
               {                 
                   if ((!isS[degree]) &&(degree != word1_index))
                   {                 
                       if (minmatrix[degree] < minweight) 
                       {  
                           minweight = minmatrix[degree];                            
                           minUn = degree;                   
                       }             
                   }  
                   degree = (degree + 1)%n;
               }             
               isS[minUn] = true;// ���õ�����Ϊ�ѷ��ʣ�      
               degree2 = word1_index;
               for (int j = 0; j < n; j++) 
               {     
                   if (!isS[degree2]) 
                   {// �жϣ��ö��㻹û���뵽S��/����U-S��                      
                       if (minweight + edge2[minUn][degree2] < minmatrix[degree2]) 
                       {                     
                       // ͨ��������Сֵ ���ʵ�����������ľ���С��ԭ�ȵ���Сֵ ����н���ֵ                     
                           minmatrix[degree2] = minweight + edge2[minUn][degree2];                       
                           route[degree2] = route[minUn] + "->" + G.words[degree2];            
                       }             
                   }  
                   degree2 = (degree2 + 1)%n;
               }  
               minweight = G.MAX_WEIGHT;// ��ΪҪ�ŵ���һ��ѭ���У�����һ��Ҫ������һ�£��ص����ֵ            
           }         
           for (int m = 0; m < n; m++) 
           {  
               if(m!=word1_index)              
           
                    if (minmatrix[m] == G.MAX_WEIGHT) 
                    {     
                        System.out.println("û�е���õ��·��");             
                    } 
                    else 
                    {            
                            sentence=sentence+route[m]+",";     
                       //System.out.println(route[m]);                     
                    } 
                }  
             
        //   }  
        //   System.out.println(sentence);
           return sentence;
             
    }
    public String Dijkstra(garph G,String word1,String word2) throws IOException
    {  
           int n = G.reallen, degree, degree2;  
           int minweight = G.MAX_WEIGHT;  
           int minUn = 0; 
           int [][] edge2 = new int[G.reallen][G.reallen];
           int[] minmatrix = new int[G.reallen];// ��ŵ�ǰ��ʼ��0�������������ľ��룻  
           boolean[] isS = new boolean[n];// �жϸ����Ƿ񱻷��ʹ�  
           String[] route = new String[n];// ÿ���ַ�������ʾ��Ӧ��ֹ������̾����·����    
           int word1_index = G.match(G.words,word1);
           if (word1_index == -1)
               return "ERROR";
           int word2_index = G.match(G.words,word2);
           if (word2_index == -1)
               return "ERROR";
           for (int i = 0 ; i < G.reallen ;i++) 
           {
                for (int j = 0 ; j < G.reallen ; j++)
                {
                    edge2[i][j]=G.edge[i][j];
                    if((i!=j)&&(edge2[i][j]==0))
                        edge2[i][j]=G.MAX_WEIGHT;
                }       
                    
            }
         //  System.out.print(reallen);
           for (int i = 0; i < n; i++) 
           if(i!=word1_index){// ��ʼ��  
               minmatrix[i] = edge2[word1_index][i];  
               isS[i] = false;  
               route[i] = G.words[word1_index] +"->" + G.words[i];    
           }  
           degree2 = word1_index;
           for (int i = 0; i < n; i++) 
           {             
           // ѡ�� ��ǰ ����� ��ͨ�ģ���ֵ��С�Ķ��㣻  
               degree = word1_index;
               for (int k = 0; k < n; k++) 
               {                 
                   if ((!isS[degree]) &&(degree != word1_index))
                   {                 
                       if (minmatrix[degree] < minweight) 
                       {  
                           minweight = minmatrix[degree];                            
                           minUn = degree;                   
                       }             
                   }  
                   degree = (degree + 1)%G.reallen;
               }             
               isS[minUn] = true;// ���õ�����Ϊ�ѷ��ʣ�      
               degree2 = word1_index;
               for (int j = 0; j < n; j++) 
               {     
                   if (!isS[degree2]) 
                   {// �жϣ��ö��㻹û���뵽S��/����U-S��                      
                       if (minweight + edge2[minUn][degree2] < minmatrix[degree2]) 
                       {                     
                       // ͨ��������Сֵ ���ʵ�����������ľ���С��ԭ�ȵ���Сֵ ����н���ֵ                     
                           minmatrix[degree2] = minweight + edge2[minUn][degree2];                       
                           route[degree2] = route[minUn] + "->" + G.words[degree2];            
                       }             
                   }  
                   degree2 = (degree2 + 1)%G.reallen;
               }  
               minweight = G.MAX_WEIGHT;// ��ΪҪ�ŵ���һ��ѭ���У�����һ��Ҫ������һ�£��ص����ֵ
               
           }
           G.weight_index=minmatrix[word2_index];
         return  route[word2_index];
         
             
    }  
}
