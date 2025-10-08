# Diceware

A .NET core library for working generating Diceware passphrases using the EFF Large Wordlist.

## Overview

This library provides a simple interface to access the [EFF Large Wordlist](https://www.eff.org/deeplinks/2016/07/new-wordlists-random-passphrases), which contains 7,776 words designed for creating secure, memorable passphrases using the Diceware method.

## Features

- Embedded EFF Large Wordlist (no external file dependencies)
- Multi-target support: .NET 6.0, .NET 8.0, and .NET 9.0
- Simple, efficient lookup by dice roll (5-digit strings)
