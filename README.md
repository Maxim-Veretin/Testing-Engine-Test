# Тестовое задание для Forward

В симуляции двигатель работает по данному в тестовом задании графику. При перегреве двигателя выводится соответствующее сообщение и время, которое он проработал без перегрева. Если заданная температура окружающей среды была низкой и двигатель отработал все состояния, отражённые на графике, считается что двигатель отработал без перегрева.

При запуске приложения в консоль вводится:
  1. Температура в градусах Цельсия;
  2. Номер типа двигателя из списка, выводящегося в консоль;
  3. Номер типа теста из списка, выводящегося в консоль;

При вводе некорректных данных (символа, не являющегося цифрой, десятичного числа при выборе типа двигателя/теста или номера двигателя/теста, которого нет в списке) в консоль выводится сообщение, содержащее тип ошибки и просьбу ввести корректные данные.
Температура в форме десятичной дроби вводится с использованием запятой.
Данные для тестирования (момент инеркции двигателя, температура перегрева и прочие) вводятся в коде класса InternalCombustionEngine.

ЛОГИЧЕСКИЕ БЛОКИ ПРИЛОЖЕНИЯ:
  1.  Симуляция двигателя внутреннего сгорания:
      
      Реализована в классе InternalCombustionEngine, который реализует интерфейс IEngine.
      Этот класс содержит свойства, необходимые для проведения рассчётов и методы:
      * Start() - запускает и проводит симуляцию работы двигателя;
      * Stop() - останавливает симуляцию;
      * GetHeatingRate(double crankshaftRotationSpeeds, double torques) - возвращает скорость нагрева двигателя при заданных крутящем моменте двигателя и скорости вращения коленвала;
      * GetCoolingRate(double TAmbient) - возвращает скорость охлаждения двигателя при заданной температуре окружающей среды.
      
      Интерфейс IEngine представляет абстрактный двигатель с минимальным набором свойств и методов, необходимых для прохождения имеющегося теста.
      
  2.  Логика тестирования двигателя на перегрев:
      
      Реализована в классе OverheatTimeTest, который реализует интерфейс ITestFactory.
      Этот класс содержит поле типа Engine - двигатель, который будет подвергаться тестированию. Конкретный тип двигателя приводится к общему типу IEngine, что позволяет работать с разными двигателями одинаково. Также, содержит методы:
      * StartSimulation() - запускает симуляцию работы двигателя;
      * Controller() - следит за температурой двигателя, если двигатель перегрелся - останавливает симуляцию;
      * OverheatTime() - возвращает время, за которое перегреется двигатель.
      
      Интерфейс ITestFactory - содержит минимальный набор свойств и методов, необходимых для каждого теста.
  
  3.  Консольный ввод-вывод, задание исходных данных и запуск теста:
      Реализован в классе Programm. Получает данные с консоли и выводит необходимые сообщения пользователю.
