using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomAnswer : MonoBehaviour
{
    
    public GameObject ansverTriangle; // Ссылка на треугольник в сцене
    public Texture[] ansvers; // Массив текстур с ответами

    private float previousTime; // Начало старта анимации
    private bool getRandomAnsver = false; // Получить рандомный ответ

    // Это устаревший класс-компонент (Legacy), но он несколько проще в понимании, чем Animator
    private Animation aminRotation; 

    void Start()
    {
        // Получаем ссылку на компонент анимации, прикрепленный к шарику
        aminRotation = GetComponent<Animation>();
    }

    void Update()
    {
        // Если нажата кнопка мышки или пробел, и анимация не проигрывается
        // Важный пример оптимизации и рефакторинга
        // Проверка аргументов идет от левого к правому
        // В начале проверки лучше проверить самое простое условие, например
        // В нашем случае это флаг, что анимация не проигрывается
        // Такая проверка происходит намного быстрее, чем проверка на нажатие
        if (!aminRotation.isPlaying && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            previousTime = Time.time; // Устанавливаем текущее время
            aminRotation.Play(); // Запускаем анимацию
            getRandomAnsver = true; // Нунжно получить ответ
        }

        // Получить рандомный ответ через полсекунды от начала анимации
        // getRandomAnsver проверяется первым
        if (getRandomAnsver && Time.time - previousTime > 0.5f)
        {
            // Мы меняем текстуру на треугольнике
            // Массив сылок на текстуры задан чeрез интерфейс Unity
            // Никаких проверок на пустые и невалидные переменные мы не делаем, рассчитываем, что дизайнер не накосячит
            ansverTriangle.GetComponent<MeshRenderer>().material.mainTexture = ansvers[Random.Range(0, ansvers.Length)];
            getRandomAnsver = false; // Ответ получен
        }

    }
}
