uv venv .venv --python 3.14 --allow-existing 2>&1 | Out-Null
.venv\Scripts\activate 2>&1 | Out-Null
uv pip install -r requirements.txt 2>&1 | Out-Null
python _fetch.py $args
