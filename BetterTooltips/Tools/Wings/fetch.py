import dataclasses
import re

import bs4
import httpx
import typer

app = typer.Typer(add_completion=False)


@dataclasses.dataclass()
class Stat:
    name: str
    id: int
    flight_time: float
    height: int
    speed_bonus: float

    def dump_vanilla(self) -> str:
        return f"Cache.Add({self.id}, new({self.flight_time}f, {self.height}, {self.speed_bonus}f)); // {self.name}"

    def dump_calamity(self) -> str:
        names = {
            "Skyline Wings": "SkylineWings",
            "Starlight Wings": "StarlightWings",
            "Aureate Booster": "AureateBooster",
            "Hadarian Wings": "HadarianWings",
            "Hadal Mantle": "HadalMantle",
            "Exodus Wings": "ExodusWings",
            "Tarragon Wings": "TarragonWings",
            "Elysian Wings": "ElysianWings",
            "Silva Wings": "SilvaWings",
            "Wings of Rebirth": "WingsofRebirth",
            "Soul of Cryogen": "SoulofCryogen",
            "MOAB": "MOAB",
            "Moon Walkers": "MoonWalkers",
            "Void Striders": "VoidStriders",
            "Seraph Tracers": "SeraphTracers",
        }
        return f'Cache.Add(Utils.FindItem(mod, "{names[self.name]}").Type, new({self.flight_time}f, {self.height}, {self.speed_bonus}f)); // {self.name}'

    def dump_thorium(self) -> str:
        names = {
            "Champion's Wings": "ChampionWing",
            "Drider's Grace": "DridersGrace",
            "Dragon's Wings": "DragonWings",
            "Flesh Wings": "FleshWings",
            "Phonic Wings": "PhonicWings",
            "Titan Wings": "TitanWings",
            "Subspace Wings": "SubspaceWings",
            "Dread Wings": "DreadWings",
            "Demon Blood Wings": "DemonBloodWings",
            "Terrarium Wings": "TerrariumWings",
            "Shooting Star Turbo Tuba": "ShootingStarTurboTuba",
            "Celestial Carrier": "CelestialCarrier",
            "White Dwarf Thrusters": "WhiteDwarfThrusters",
        }
        return f'Cache.Add(Utils.FindItem(mod, "{names[self.name]}").Type, new({self.flight_time}f, {self.height}, {self.speed_bonus}f)); // {self.name}'


@app.command()
def vanilla() -> None:
    """
    Fetch stats from https://terraria.wiki.gg/wiki/Wings.
    """
    response = httpx.get("https://terraria.wiki.gg/wiki/Wings/List")
    soup = bs4.BeautifulSoup(response.content, "html.parser")

    stats: list[Stat] = []
    for row in soup.find("table").find_all("tr")[1:]:  # type: ignore
        cols = row.find_all(["td", "th"])
        if len(cols) < 10:
            continue

        value = cols[1].get_text(strip=True)
        result = re.search(r"(?P<name>.+)InternalItem ID: (?P<id>.+)", value)
        name, id = result.group("name"), int(result.group("id"))  # type: ignore

        value = cols[4].get_text(strip=True)
        result = re.search(r"(.+)\u00a0", value)
        flight_time = float(result.group(0))  # type: ignore

        value = cols[5].get_text(strip=True)
        height = int(value)  # type: ignore

        value = cols[7].get_text(strip=True)
        result = re.search(r"(\d+)", value)
        speed_bonus = (float(result.group(0)) / 100.0) - 1.0  # type: ignore

        stats.append(Stat(name, id, flight_time, height, speed_bonus))

    for stat in stats:
        print(stat.dump_vanilla())

    return None


@app.command()
def calamity() -> None:
    """
    Fetch stats from https://calamitymod.wiki.gg/wiki/Wings.
    """
    response = httpx.get("https://calamitymod.wiki.gg/wiki/Wings")
    soup = bs4.BeautifulSoup(response.content, "html.parser")
    tables = soup.find_all("table")
    tables = [tables[1], tables[2]]

    stats: list[Stat] = []
    for table in tables:
        for row in table.find_all("tr")[1:]:
            cols = row.find_all(["td", "th"])
            if len(cols) < 10:
                continue

            value = cols[1].get_text(strip=True)
            name, id = value, 0  # type: ignore

            value = cols[4].get_text(strip=True)
            flight_time = float(value)  # type: ignore

            value = cols[5].get_text(strip=True)
            result = re.search(r"(\d+)", value)
            height = int(result.group(0))  # type: ignore

            value = cols[6].get_text(strip=True)
            result = re.search(r"(\d+)", value)
            speed_bonus = float(result.group(0)) / 100.0  # type: ignore

            stats.append(Stat(name, id, flight_time, height, speed_bonus))

    for stat in stats:
        print(stat.dump_calamity())

    return None


@app.command()
def thorium() -> None:
    """
    Fetch stats from https://thoriummod.wiki.gg/wiki/Wings.
    """
    response = httpx.get("https://thoriummod.wiki.gg/wiki/Wings")
    soup = bs4.BeautifulSoup(response.content, "html.parser")

    stats: list[Stat] = []
    for row in soup.find_all("table")[1].find_all("tr")[1:]:
        cols = row.find_all(["td", "th"])
        if len(cols) < 10:
            continue

        value = cols[1].get_text(strip=True)
        name, id = value, 0  # type: ignore

        value = cols[4].get_text(strip=True)
        result = re.search(r"(\d+)", value)
        flight_time = float(result.group(0))  # type: ignore

        value = cols[5].get_text(strip=True)
        result = re.search(r"(\d+)", value)
        height = int(result.group(0))  # type: ignore

        value = cols[6].get_text(strip=True)
        result = re.search(r"(\d+)", value)
        speed_bonus = float(result.group(0)) / 100.0  # type: ignore

        stats.append(Stat(name, id, flight_time, height, speed_bonus))

    for stat in stats:
        print(stat.dump_thorium())

    return None


if __name__ == "__main__":
    app()
