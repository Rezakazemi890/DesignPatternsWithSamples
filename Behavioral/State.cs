﻿namespace DesignPattern.Behavioral;

using System;

/// <summary>
/// The State Design Pattern is a behavioral design pattern that allows an object to alter its behavior when its internal state changes.
/// The pattern encapsulates state-specific behavior into separate classes and delegates the responsibility of managing the state
/// to these classes. This promotes a clean and modular design, making it easier to add new states or modify existing ones without
/// affecting the overall functionality.
/// </summary>
public abstract class State
{
    public interface ITrafficLightState
    {
        void Handle(TrafficLight trafficLight);
    }

    private class RedState : ITrafficLightState
    {
        public void Handle(TrafficLight trafficLight)
        {
            Console.WriteLine("Traffic Light is RED. Stop!");
            // Transition to the next state (Yellow)
            trafficLight.SetState(new YellowState());
        }
    }

    private class YellowState : ITrafficLightState
    {
        public void Handle(TrafficLight trafficLight)
        {
            Console.WriteLine("Traffic Light is YELLOW. Slow down!");
            // Transition to the next state (Green)
            trafficLight.SetState(new GreenState());
        }
    }

    private class GreenState : ITrafficLightState
    {
        public void Handle(TrafficLight trafficLight)
        {
            Console.WriteLine("Traffic Light is GREEN. Go!");
            // Transition to the next state (Red)
            trafficLight.SetState(new RedState());
        }
    }

    public class TrafficLight
    {
        private ITrafficLightState _currentState;

        internal TrafficLight()
        {
            // Initial state is Red
            _currentState = new RedState();
        }

        internal void SetState(ITrafficLightState state)
        {
            _currentState = state;
        }

        internal void Change()
        {
            _currentState.Handle(this);
        }
    }
}