using System;
using Welcome.Model;

public delegate void ActionOnError(string errorMessage);
public delegate void ActionOnLoginAttempt(string errorMessage, DateTime dateTime);
public delegate void ActionOnLogin(User user);