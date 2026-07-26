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
    reach: int
    velocity: int
    hooks: int

    def dump_vanilla(self) -> str:
        return f"Cache.Add({self.id}, new({self.reach}, {self.velocity}, {self.hooks})); // {self.name}"

    def dump_calamity(self) -> str:
        names = {
            "Serpent's Bite": "SerpentsBite",
            "Bobbit Hook": "BobbitHook",
        }
        return f'Cache.Add(Utils.FindItem(mod, "{names[self.name]}").Type, new({self.reach}, {self.velocity}, {self.hooks})); // {self.name}'

    def dump_thorium(self) -> str:
        names = {
            "Zephyr's Grip": "ZephyrsGrip",
            "Opal Hook": "OpalHook",
            "Aquamarine Hook": "AquamarineHook",
            "Spring Hook": "SpringHook",
            "Jeweller's Wall Grip": "JewellersWallGrip",
            "Leviathan": "Leviathan",
            "Devil's Reach": "DevilsReach",
            "Fungal Hook": "FungalHook",
            "Neptune's Grasp": "NeptuneGrasp",
            "Ammutseba's Sash": "AmmutsebaSash",
            "Ghostly Grapple": "GhostlyGrapple",
        }
        return f'Cache.Add(Utils.FindItem(mod, "{names[self.name]}").Type, new({self.reach}, {self.velocity}, {self.hooks})); // {self.name}'


@app.command()
def vanilla() -> None:
    """
    Fetch stats from https://terraria.wiki.gg/wiki/Hooks.
    """
    response = httpx.get("https://terraria.wiki.gg/wiki/Hooks")
    soup = bs4.BeautifulSoup(response.content, "html.parser")
    tables = soup.find_all("table")
    tables = [tables[1], tables[2]]

    stats: list[Stat] = []
    for table in tables:
        for row in table.find_all("tr")[1:]:  # type: ignore
            cols = row.find_all(["td", "th"])
            if len(cols) < 7:
                continue

            value = cols[1].get_text(strip=True)
            result = re.search(r"(?P<name>.+)InternalItem ID: (?P<id>.+)", value)
            name, id = result.group("name"), int(result.group("id"))  # type: ignore

            value = cols[5].get_text(strip=True)
            reach = int(float(value) + 0.5)

            value = cols[6].get_text(strip=True)
            velocity = int(float(value) * 42240.0 / 216000.0 + 0.5)

            value = cols[3].get_text(strip=True)
            hooks = int(value)

            stats.append(Stat(name, id, reach, velocity, hooks))

    for stat in stats:
        print(stat.dump_vanilla())

    return None


@app.command()
def calamity() -> None:
    """
    Fetch stats from https://calamitymod.wiki.gg/wiki/Hooks.
    """
    response = httpx.get("https://calamitymod.wiki.gg/wiki/Hooks")
    soup = bs4.BeautifulSoup(response.content, "html.parser")

    stats: list[Stat] = []
    for row in soup.find_all("table")[1].find_all("tr")[1:]:
        cols = row.find_all(["td", "th"])
        if len(cols) < 6:
            continue

        value = cols[1].get_text(strip=True)
        name, id = value, 0  # type: ignore

        value = cols[3].get_text(strip=True)
        reach = int(float(value) + 0.5)

        value = cols[4].get_text(strip=True)
        velocity = int(float(value) + 0.5)

        value = cols[5].get_text(strip=True)
        hooks = int(value)

        stats.append(Stat(name, id, reach, velocity, hooks))

    for stat in stats:
        print(stat.dump_calamity())

    return None


@app.command()
def thorium() -> None:
    """
    Fetch stats from https://thoriummod.wiki.gg/wiki/Hooks.
    """
    response = httpx.get("https://thoriummod.wiki.gg/wiki/Hooks")
    soup = bs4.BeautifulSoup(response.content, "html.parser")
    tables = soup.find_all("table")
    tables = [tables[0], tables[1]]

    stats: list[Stat] = []
    for table in tables:
        for row in table.find_all("tr")[1:]:
            cols = row.find_all(["td", "th"])
            if len(cols) < 6:
                continue

            value = cols[1].get_text(strip=True)
            name, id = value, 0  # type: ignore

            value = cols[3].get_text(strip=True)
            reach = int(float(value) + 0.5)

            value = cols[4].get_text(strip=True)
            velocity = int(float(value) + 0.5)

            value = cols[5].get_text(strip=True)
            hooks = int(value)

            stats.append(Stat(name, id, reach, velocity, hooks))

    for stat in stats:
        print(stat.dump_thorium())

    return None


if __name__ == "__main__":
    app()
