/**
 * 
 */
package lab7;

import java.io.IOException;

/**
 * @author Administrator
 *
 */
public class BridgeWords {
    String Bridge_word = "";
    String queryBridgeWords(garph G,String word1, String word2) throws IOException
    {     
        int i, j, k; //i,j�ֱ��ʾword1��word2��ͼ�е�λ��
        boolean result = false , find1 , find2 ; //��־��ͼ���ܷ��ҵ����뵥��
        find1 = false;
        find2 = false;
        for (i = 0 ; i < G.reallen ; i++)
            if (word1.equals(G.words[i]))
            {
                find1 = true;
                break;
            }
        for (j = 0 ; j < G.reallen ; j++)
            if (word2.equals(G.words[j]))
            {
                find2 = true;
                break;
            }
        if (find1 == false && find2 == false)
            return "error1";
        else if (find1 == false)
            return "error2";
        else if(find2 == false)
            return "error3";
        for (k = 0 ; k < G.reallen ; k++)
            if ((k!=i)&&(k!=j)&&(G.edge[i][k]>0)&&(G.edge[k][j]>0))
            {
                Bridge_word = Bridge_word + G.words[k] + " ,";
                result = true;
            }
        if (result == false)
            return "error4";
        else
            return Bridge_word; 
    }
}
