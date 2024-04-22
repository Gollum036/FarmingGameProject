using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plantar : MonoBehaviour
{
    public GameObject[] prefabsToInstantiate; // Array de prefabs a serem instanciados
    public float delayBetweenInstances = 5.0f; // Delay entre cada inst�ncia

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que colidiu possui a tag desejada (ou outra condi��o de sua escolha)

        // Inicia a rotina que instancia os prefabs com delay
        StartCoroutine(InstantiatePrefabsWithDelay());
    }

    IEnumerator InstantiatePrefabsWithDelay()
    {
        GameObject previousPrefab = null;

        // Itera sobre todos os prefabs no array
        foreach (GameObject prefab in prefabsToInstantiate)
        {
            // Instancia o prefab na mesma posi��o e rota��o que este objeto
            GameObject newObject = Instantiate(prefab, transform.position, transform.rotation);

            // Se houver um prefab anterior, destrua-o
            if (previousPrefab != null)
            {
                Destroy(previousPrefab);
            }

            // Aguarda o delay antes de instanciar o pr�ximo prefab
            yield return new WaitForSeconds(delayBetweenInstances);

            // Define o prefab atual como o anterior para a pr�xima itera��o
            previousPrefab = newObject;
        }

        // Destroi este objeto ap�s instanciar todos os prefabs
        Destroy(gameObject);
    }

}
